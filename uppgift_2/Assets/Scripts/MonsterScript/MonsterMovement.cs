using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	MonsterSuperScript mss;

	int speed = 3;
	Vector3 direction = Vector3.zero;
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
 
		direction.z = Input.GetAxis ("WASD-Horizontal");
		direction.y = Input.GetAxis ("WASD-Vertical");
		direction.x = Input.GetAxis ("QE");
		direction.Normalize ();
		direction *= speed * Time.deltaTime;
		cc.Move (direction);
		transform.LookAt (transform.position + direction);
	}
}
