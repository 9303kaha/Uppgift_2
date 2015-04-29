using UnityEngine;
using System.Collections;

public class MonsterStat : MonoBehaviour
{
	MonsterSuperScript mss;

	int health = 150;
	int shield = 50;
	float fireRate = 1.5f;

	void Start(){
	
	}

	public void Setup(MonsterSuperScript monsterSS){
		mss = monsterSS;
	}

	void Update(){

	}

	public float getFireRate ()
	{
		return fireRate;
	}
}

