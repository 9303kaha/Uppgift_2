using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	int speed = 6;
	float lift = 0.4f; 
	Vector3 direction = Vector3.zero;
	CharacterController cc;
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
 
		direction.z = Input.GetAxis ("WASD-Horizontal");
		direction.y = Input.GetAxis ("WASD-Vertical");
		direction.Normalize ();
		direction *= speed * Time.deltaTime;
		cc.Move (direction);
		transform.LookAt (transform.position + direction);
	}
}
