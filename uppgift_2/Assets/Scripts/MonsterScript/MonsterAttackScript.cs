using UnityEngine;
using System.Collections;

public class MonsterAttackScript : MonoBehaviour {

	MonsterSuperScript mss;
	public Transform bulletPrefab;
	Ray ray;
	RaycastHit hit;
	Vector3 hitPosition;
	Vector3 targetDirection;
	float rotAngle = 0.0f;
	float bulletForce = 6.0f;
	Transform cannon;

	float attackTimer;

	// Use this for initialization
	void Start () {
		cannon = transform.FindChild ("Cannon").transform;
		attackTimer = 0;
	}

	public void Setup(MonsterSuperScript monsterSS){
		mss = monsterSS;
	}

	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 100)) {
			hitPosition = hit.point;
			targetDirection = hitPosition - transform.position;
			targetDirection.Normalize();
			cannon.position = transform.position + 0.5f * targetDirection; //rotates the cannon around the monster
			cannon.LookAt(transform.position + targetDirection); //rotates the cannon around itself
			rotAngle = Mathf.Atan2(targetDirection.y, targetDirection.z);
			if(targetDirection.y < 0 && targetDirection.z < 0){rotAngle -= Mathf.PI;}
			rotAngle *= -180/Mathf.PI; //Determines the angle the cannon is rotated around itself
		}
		attackTimer += Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.Mouse0) && attackTimer >= mss.ms.getFireRate()) {
			Fire ();
			attackTimer = 0;
		}
	}

	void Fire(){
		Transform bullet = (Transform)Instantiate (bulletPrefab, cannon.position + cannon.forward * 0.3f, Quaternion.Euler (rotAngle, 0, 0) * bulletPrefab.transform.rotation);
		bullet.GetComponent<Rigidbody> ().AddForce (cannon.forward * bulletForce, ForceMode.Impulse);
	}
}
