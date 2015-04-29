using UnityEngine;
using System.Collections;

public class PlayerSuperScript : MonoBehaviour {
	
	public ControllerDetectionScript cds;
	public PlayerMovement pm;
	public CharacterStat cs;
	public PlayerAttack pa;

	// Use this for initialization
	void Start () {
		cds = GetComponent<ControllerDetectionScript> ();
		pm = GetComponent<PlayerMovement> ();
		cs = GetComponent<CharacterStat> ();

		Setup ();
	}

	void Setup(){
		cds.Setup (this);
		pm.Setup (this);
		cs.Setup (this);
		pa.Setup (this);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
