using UnityEngine;
using System.Collections;

public class PlayerMeleeAttack : PlayerAttack {

	PlayerSuperScript pss;

	// Use this for initialization
	void Start () {
	
	}

	public override void Setup(PlayerSuperScript playerSS){
		pss = playerSS;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Attack(){

	}
}
