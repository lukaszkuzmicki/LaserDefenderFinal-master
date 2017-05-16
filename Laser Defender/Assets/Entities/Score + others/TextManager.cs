using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public static Text myText;
	

	void Start(){
		myText = GetComponent<Text>();
		
		
	}
	void Update(){TextEditor();}
	
	public static void TextEditor(){
 		myText.text = "Level 0";
 		if(ScoreKeeper.score > 1000){
			myText.text = "Level 1";
 		}
		if(ScoreKeeper.score > 2000){
			myText.text = "Level 2";
		}
		if(ScoreKeeper.score > 5000){
			myText.text = "Level 3";
		}
		if(ScoreKeeper.score > 10000){
			myText.text = "Level 4";
		}
		if(ScoreKeeper.score > 15000){
			myText.text = "Level 5";
		}
	}
	
}
