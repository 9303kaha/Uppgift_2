using UnityEngine;
using System.Collections;

public class MonsterStat : MonoBehaviour
{
	MonsterSuperScript mss;

	int health = 150;
	int healthMax = 150;
	int shield = 50;
	int shieldMax = 50;
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

	public int[] getHealthInfo(){
		return new int[] {health, healthMax, shield, shieldMax};
	}

	public void Damage(int damage){
		print ("Damage taken by bird!");
		switch (mss.pt.GetPhase ()) {
		case 1:
			shield -= damage;
			if (shield <= 0){
				health += shield;
				mss.pt.shiftPhase(); //Shifting into the ground-based Phase 2 of the game
			}
			break;
		case 2:
			health -= damage;
			break;
		}
	}
}

