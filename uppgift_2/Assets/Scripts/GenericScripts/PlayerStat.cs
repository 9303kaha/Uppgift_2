using UnityEngine;
using System.Collections;

public abstract class PlayerStat : MonoBehaviour {

	public virtual void Setup(PlayerSuperScript pss){

	}

	public virtual void Setup(MonsterSuperScript mss){
	
	}

	public abstract void Damage(int damage);
}
