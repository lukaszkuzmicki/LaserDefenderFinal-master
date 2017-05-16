using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScore : MonoBehaviour {

private Text myText;
	
	
void Start(){
	myText = GetComponent<Text>();		
	myText.text = ScoreKeeper.score.ToString();
	ScoreKeeper.Reset();
}

}
