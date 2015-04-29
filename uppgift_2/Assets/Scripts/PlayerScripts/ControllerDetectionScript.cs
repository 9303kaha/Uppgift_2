using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class ControllerDetectionScript : MonoBehaviour {

	bool playerIndexSet = false;
	PlayerSuperScript pss;
	PlayerIndex pi;
	GamePadState prevState;
	GamePadState curState;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!playerIndexSet || !prevState.IsConnected) {
			
			for(int i=0; i<4;i++){
				PlayerIndex testPlayerIndex = (PlayerIndex) i;
				GamePadState testState = GamePad.GetState(testPlayerIndex);
				if(testState.IsConnected){
					pi = testPlayerIndex;
					playerIndexSet = true;
				}
			}
		}
		
		prevState = curState;
		curState = GamePad.GetState (pi);
	}

	public void Setup(PlayerSuperScript playerSS){
		pss = playerSS;
	}

	public GamePadState getPrevState(){
		return prevState;
	}

	public GamePadState getCurState(){
		return curState;
	}
}
