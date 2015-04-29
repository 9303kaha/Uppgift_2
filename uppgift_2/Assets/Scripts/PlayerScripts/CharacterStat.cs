using UnityEngine;
using System.Collections;

public class CharacterStat : MonoBehaviour {

	public int characterType = 0; //1 for Player 1, 2 for Player 2

	PlayerSuperScript pss;

	// Use this for initialization
	void Start () {
	
	}

	public void Setup(PlayerSuperScript playerSS){
		pss = playerSS;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
