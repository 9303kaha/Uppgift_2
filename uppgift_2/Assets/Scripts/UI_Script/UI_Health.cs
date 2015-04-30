using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Health : MonoBehaviour {

	CharacterStat p1, p2;
	MonsterStat p3;
	Text p1Text, p2Text, p3HealthText, p3ShieldText;

	// Use this for initialization
	void Start () {
		p1 = GameObject.Find ("Ranged_Player").GetComponent<CharacterStat> ();
		p2 = GameObject.Find ("Melee_Player").GetComponent<CharacterStat> ();
		p3 = GameObject.Find ("Monster_Player").GetComponent<MonsterStat> ();
		p1Text = GameObject.Find ("P1_HealthText").GetComponent<Text> ();
		p2Text = GameObject.Find ("P2_HealthText").GetComponent<Text> ();
		p3HealthText = GameObject.Find ("P3_HealthText").GetComponent<Text> ();
		p3ShieldText = GameObject.Find ("P3_ShieldText").GetComponent<Text> ();

		p1Text.rectTransform.anchoredPosition = new Vector2 (Screen.width / 2, 0);
		p2Text.rectTransform.anchoredPosition = Vector2.zero;
		p3HealthText.rectTransform.anchoredPosition = new Vector2 (0, -Screen.height / 2);
		p3ShieldText.rectTransform.anchoredPosition = new Vector2 (0, -Screen.height / 2 - 15);
	}
	
	// Update is called once per frame
	void Update () {
		p1Text.text = "Health: " + p1.getHealth () [0] + "/" + p1.getHealth () [1];
		p2Text.text = "Health: " + p2.getHealth () [0] + "/" + p2.getHealth () [1];
		p3HealthText.text = "Health: " + p3.getHealthInfo () [0] + "/" + p3.getHealthInfo () [1];
		p3ShieldText.text = "Shield: " + p3.getHealthInfo () [2] + "/" + p3.getHealthInfo () [3];
	}
}
