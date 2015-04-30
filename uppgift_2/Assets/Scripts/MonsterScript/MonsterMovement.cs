using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	MonsterSuperScript mss;

	int speed = 3;
	Vector3 direction = Vector3.zero;
	Vector3 lookatVector = Vector3.zero;
	CharacterController cc;
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}

	public void Setup(MonsterSuperScript monsterSS){
		mss = monsterSS;
	}
	// Update is called once per frame
	void Update () {
		switch(mss.pt.GetPhase()){
		case 1:
		direction.z = Input.GetAxis ("QE");
		direction.y = Input.GetAxis ("WASD-Vertical");
		direction.x = Input.GetAxis ("WASD-Horizontal");
		direction.Normalize ();
		direction *= speed * Time.deltaTime;
		cc.Move (direction);
		lookatVector = direction; 
		lookatVector.y = 0;
		transform.LookAt (transform.position + lookatVector);
			break;
		case 2:
			direction.z = Input.GetAxis ("QE");
			direction.y = -4;
			direction.x = Input.GetAxis ("WASD-Horizontal");
			direction.Normalize();
			direction *= speed * Time.deltaTime;
			cc.Move(direction);
			lookatVector = direction; 
			lookatVector.y = 0;
			transform.LookAt (transform.position + lookatVector);
			break;
		}
	}
}
