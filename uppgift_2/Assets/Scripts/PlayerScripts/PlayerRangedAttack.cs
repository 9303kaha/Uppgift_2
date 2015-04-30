using UnityEngine;
using System.Collections;

public class PlayerRangedAttack : PlayerAttack {

	PlayerSuperScript pss;
	public Transform bulletPrefab;
	public Transform healPrefab;
	Transform cannonPoint;
	float bulletForce = 6.0f;

	// Use this for initialization
	void Start () {
		cannonPoint = transform.FindChild ("CannonPoint");
	}

	public override void Setup(PlayerSuperScript playerSS){
		pss = playerSS;
	}

	public override void Attack(){
		Transform bullet = (Transform)Instantiate (bulletPrefab, cannonPoint.position, Quaternion.identity);
		bullet.GetComponent<Rigidbody> ().AddForce (cannonPoint.forward * bulletForce, ForceMode.Impulse);
		bullet.GetComponent<Bullet> ().setDamage (3);
	}

	public override void Special(){
		RaycastHit hit;
		if (Physics.Raycast (cannonPoint.position, transform.forward, out hit, 100)) {
			if (hit.collider.GetComponent<CharacterStat> ()) {
				CharacterStat cs = hit.collider.GetComponent<CharacterStat> ();
				cs.Heal(1);
			}
		}
	}

	public override void SpecialEnd(){

	}
	
	// Update is called once per frame

}
