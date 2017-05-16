using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {


	public static Text hpText;
	// Use this for initialization
	void Start () {
		hpText = GetComponent<Text>();
		hpText.text = PlayerController.health.ToString();
				
	}
	public static void UpdateHP(){
		hpText.text = PlayerController.health.ToString();
		Debug.Log("test");
	}

	
}
