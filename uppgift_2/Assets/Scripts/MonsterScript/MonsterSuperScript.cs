using UnityEngine;
using System.Collections;

public class MonsterSuperScript : MonoBehaviour {

	// Use this for initialization
	public MonsterMovement mm;
	public MonsterStat ms;
	public MonsterAttackScript mas;

	void Start () {
	
		mm = GetComponent<MonsterMovement> ();
		ms = GetComponent<MonsterStat> ();
		mas = GetComponent<MonsterAttackScript> ();

		Setup ();


	}

	void Setup(){
	
		mm.Setup (this);
		ms.Setup (this);
		mas.Setup (this);
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
