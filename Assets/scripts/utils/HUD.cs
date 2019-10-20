using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

static class HUD {


	static public int score;
	static Text hudText;

	static public void Initialize(){
		score = 0;
		hudText = GameObject.FindGameObjectWithTag ("hudtext").GetComponent<Text> ();
		hudText.text = "Score = 0";
		EventManager.AddHudListener (IncrementScore);
	}

	static public void IncrementScore(int points){
		score += points;
		hudText.text = "Score = " + score.ToString ();
	}


}
