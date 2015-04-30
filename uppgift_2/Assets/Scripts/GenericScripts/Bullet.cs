using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setDamage(int dmg){
		damage = dmg;
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.GetComponent<PlayerStat> ()) {
			if	(c.gameObject.GetComponent<CharacterStat> ()){
				CharacterStat cs = c.gameObject.GetComponent<CharacterStat>();
				cs.Damage(damage);
			}
			if (c.gameObject.GetComponent<MonsterStat>()){
				print (c.transform.name);
				MonsterStat ms = c.transform.parent.gameObject.GetComponent<MonsterStat>();
				ms.Damage(damage);
			}
		}
		Destroy (gameObject);
	}
}
