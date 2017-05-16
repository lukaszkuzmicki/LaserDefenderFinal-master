using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LevelDisplay : MonoBehaviour {

	Animator animator ;		
	Text levelText;
	bool gameStarted;
	bool level1;
	bool level2;
	bool level3;
	bool level4;

	// Use this for initialization
	void Start () {
	gameStarted = true;
	level1 = true;
	level2 = true;
	level3 = true;
	level4 = true;
	
	levelText = GetComponent<Text>();	
	animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	if(ScoreKeeper.score == 0 && gameStarted){
		animator.Play("newAnimation");
		levelText.text = "Gool Luck!!";
		gameStarted = false;
	}
	
	if(ScoreKeeper.score > 1000 && level1){
		animator.Play("newAnimation");
		levelText.text = "Level 1";
		level1 = false;
	}
	if(ScoreKeeper.score > 2500 && level2){
			animator.Play("newAnimation");
			levelText.text = "Level 2";
			level2 = false;
	}
	if(ScoreKeeper.score > 4000 && level3){
			animator.Play("newAnimation");
			levelText.text = "Level 3";
			level3 = false;
	}
	
	if(ScoreKeeper.score > 6000 && level4){
			animator.Play("newAnimation");
			levelText.text = "Level 4";
			level4 = false;
	}
	
}
}
