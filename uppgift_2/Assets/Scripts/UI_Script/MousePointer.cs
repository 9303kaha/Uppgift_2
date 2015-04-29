using UnityEngine;
using System.Collections;

public class MousePointer : MonoBehaviour {

	public Canvas canvas;
	public Camera camera;
	Vector2 pos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RectTransformUtility.ScreenPointToLocalPointInRectangle ((RectTransform)canvas.transform, Input.mousePosition, null, out pos);

		transform.position = canvas.transform.TransformPoint (pos);
		if (transform.position.y > Screen.height / 2) {
			transform.position = new Vector3(transform.position.x, Screen.height / 2, transform.position.z);
		}
	}
}
