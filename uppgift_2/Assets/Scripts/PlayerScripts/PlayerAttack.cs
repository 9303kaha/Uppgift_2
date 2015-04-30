using UnityEngine;
using System.Collections;

abstract public class PlayerAttack : MonoBehaviour {

	abstract public void Setup (PlayerSuperScript playerSS);

	void Update () {
	
	}

	abstract public void SpecialEnd ();

	abstract public void Attack();

	abstract public void Special();
}
