using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerMovement : MonoBehaviour {
	Vector3 direction;
	PlayerSuperScript pss;
	Rigidbody rb;

	Animator anim;
	Vector3 rotationVector;
	Transform playerCamera;

	// Use this for initialization
	void Start () {
		direction = Vector3.zero;
		rotationVector = Vector3.zero;
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}

	public void Setup(PlayerSuperScript playerSS){
		pss = playerSS;
	}

	bool isGrounded(){
		return Physics.Raycast (transform.position, -Vector3.up, GetComponent<Collider> ().bounds.extents.y + 0.1f);
	}

	public void PostSetup(){
		playerCamera = pss.hcs.playerCamera;
	}
	// Update is called once per frame
	void Update () {

		direction.z = pss.cds.getCurState().ThumbSticks.Left.Y;
		direction.x = pss.cds.getCurState().ThumbSticks.Left.X; //Reads input from thumbsticks
		direction.Normalize ();
		if (direction.magnitude > 0) {
			anim.SetBool ("running", true);
		} else {
			anim.SetBool("running",false);
		}
		rotationVector = pss.hcs.getRotation();

		transform.rotation = Quaternion.AngleAxis (rotationVector.y, Vector3.up) * transform.rotation;
		Vector3 travelVector = transform.TransformDirection(direction);

		rb.MovePosition (transform.position + travelVector * Time.deltaTime);

		if (xInputCheckKeyState (pss.cds.getPrevState().Buttons.X, pss.cds.getCurState().Buttons.X) == 1) {
			pss.pa.Attack();
		}

		if (xInputCheckKeyState (pss.cds.getPrevState().Buttons.B, pss.cds.getCurState().Buttons.B) == 2) {
			pss.pa.SpecialEnd();
		}
		if (xInputCheckKeyState (pss.cds.getPrevState().Buttons.B, pss.cds.getCurState().Buttons.B) == 3) {
			pss.pa.Special();
		}

	}

	void FixedUpdate(){
		//(Used mainly for rigidbody interactions that require a fixed update.) 

		//Jumping
		if (xInputCheckKeyState (pss.cds.getPrevState().Buttons.A, pss.cds.getCurState().Buttons.A) == 1 && isGrounded()) {
			rb.AddForce(0,7.5f,0,ForceMode.Impulse);
		}

		//Gravity
		rb.AddForce (0, -9, 0, ForceMode.Acceleration);
	}
	int xInputCheckKeyState(ButtonState prev, ButtonState cur){
		if (prev == ButtonState.Released && cur == ButtonState.Pressed) //Button pressed
			return 1;
		else if (prev == ButtonState.Pressed && cur == ButtonState.Released) //Button released
			return 2;
		else if (prev == ButtonState.Pressed && cur == ButtonState.Pressed) //Button held down
			return 3;
		else
			return 0;
	}
}
