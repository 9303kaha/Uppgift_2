using UnityEngine;
using System.Collections;

abstract public class PlayerAttack : MonoBehaviour {

	PlayerSuperScript pss;

	abstract public void Setup (PlayerSuperScript playerSS);

	void Update () {
	
	}

	abstract public void Attack();
}
