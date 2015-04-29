using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerMovement : MonoBehaviour {
	Vector3 direction;
	PlayerSuperScript pss;
	Rigidbody rb;

	float rotSpeed = 180;
	Vector3 rotationVector;
	Transform playerCamera;

	// Use this for initialization
	void Start () {
		direction = Vector3.zero;
		playerCamera = transform.GetChild (0);
		rotationVector = Vector3.zero;
		rb = GetComponent<Rigidbody> ();
	}

	public void Setup(PlayerSuperScript playerSS){
		pss = playerSS;
	}
	// Update is called once per frame
	void Update () {
		direction.z = pss.cds.getCurState().ThumbSticks.Left.Y;
		direction.x = pss.cds.getCurState().ThumbSticks.Left.X;

		direction.Normalize ();
		direction *= Time.deltaTime;

		rotationVector.x = -rotSpeed * pss.cds.getCurState().ThumbSticks.Right.Y;
		rotationVector.y = rotSpeed * pss.cds.getCurState().ThumbSticks.Right.X;
		rotationVector *= Time.deltaTime;
		playerCamera.localEulerAngles = playerCamera.localEulerAngles + rotationVector;

		direction = Quaternion.Euler(playerCamera.localEulerAngles) * direction;
		direction.y = 0;

		rb.MovePosition (transform.position + direction);

	}

	void FixedUpdate(){
		//(Used mainly for rigidbody interactions that require a fixed update.) 

		//Jumping
		if (xInputCheckKeyState (pss.cds.getPrevState().Buttons.A, pss.cds.getCurState().Buttons.A) == 1) {
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
