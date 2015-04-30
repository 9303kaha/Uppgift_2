using UnityEngine;
using System.Collections;

public class PlayerSuperScript : MonoBehaviour {
	
	public ControllerDetectionScript cds;
	public PlayerMovement pm;
	public CharacterStat cs;
	public PlayerAttack pa;
	public HeadCameraScript hcs;
	public PhaseTracker pt;

	// Use this for initialization
	void Start () {
		cds = GetComponent<ControllerDetectionScript> ();
		pm = GetComponent<PlayerMovement> ();
		cs = GetComponent<CharacterStat> ();
		pa = GetComponent<PlayerAttack> ();
		hcs = GetComponentInChildren<HeadCameraScript> ();
		pt = GameObject.Find ("PhaseTracker").GetComponent<PhaseTracker> ();

		Setup ();
		PostSetup ();
	}

	void Setup(){
		cds.Setup (this);
		pm.Setup (this);
		cs.Setup (this);
		pa.Setup (this);
		hcs.Setup (this);
	}

	void PostSetup(){
		pm.PostSetup ();
	}

	// Update is called once per frame
	void Update () {
	}
}
