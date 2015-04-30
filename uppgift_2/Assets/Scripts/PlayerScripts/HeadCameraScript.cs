using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class HeadCameraScript : MonoBehaviour {

	public Transform playerCamera;
	Vector3 rotationVector;
	PlayerSuperScript pss;

	float rotSpeed = 36;

	// Use this for initialization
	void Start () {
		playerCamera = transform.FindChild ("Player_Camera");
		rotationVector = Vector3.zero;
	}

	public void Setup(PlayerSuperScript playerSS){
		pss = playerSS;
	}
	
	// Update is called once per frame
	void Update () {
		rotationVector.y = rotSpeed * pss.cds.getCurState().ThumbSticks.Right.X;
		rotationVector *= Time.deltaTime;
	}

	public Vector3 getRotation(){
		return rotationVector * 180 / Mathf.PI;
	}
}
