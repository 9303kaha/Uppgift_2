using UnityEngine;
using System.Collections;

public class CharacterStat : PlayerStat {

	PlayerSuperScript pss;
	int health = 10;
	int maxHealth = 10;
	bool isShielded = false;

	// Use this for initialization
	void Start () {
	
	}

	public override void Setup(PlayerSuperScript playerSS){
		pss = playerSS;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int[] getHealth ()
	{
		return new int[] {health, maxHealth};
	}

	public override void Damage(int damage){
		print (isShielded);
		if (!isShielded && damage > 0) {
			health -= damage;
		}
		print (health);
	}

	public void setShielded (bool b)
	{
		isShielded = b;
	}

	public void Heal(int heal){
		if (heal > 0) {
			health += Mathf.Max (0, heal);
			if (health > maxHealth)
				health = maxHealth;
		}

	}
}
