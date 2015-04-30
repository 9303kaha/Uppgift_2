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
		Collider[] temp = Physics.OverlapSphere (transform.position, 3);
		for (int i=0; i<temp.Length; i++) {
			if(temp[i].gameObject.GetComponent<MonsterStat>()){
				MonsterStat ms = temp[i].GetComponent<MonsterStat>();
				ms.Damage(3);
			}
		}
	}

	public override void Special(){
		pss.cs.setShielded (true);
	}

	public override void SpecialEnd(){
		pss.cs.setShielded (false);
	}
}
