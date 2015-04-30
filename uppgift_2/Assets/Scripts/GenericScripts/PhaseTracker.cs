using UnityEngine;
using System.Collections;

public class PhaseTracker : MonoBehaviour {

	int curPhase;

	// Use this for initialization
	void Start () {
		curPhase = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int GetPhase(){
		return curPhase;
	}

	public void shiftPhase(){
		curPhase = 2;
	}
}
