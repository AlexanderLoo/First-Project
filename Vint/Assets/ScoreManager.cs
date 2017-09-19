using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private Text scoreText;
	public int totalScore;

	void Awake(){

		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
	}

	void Start(){

		scoreText.text = "Score: 0";
	}

	void Update(){
		//Actualizamos el score total en el scoreText
		scoreText.text = "Score: " + totalScore.ToString();
		BestScoreManager ();
	}

	void BestScoreManager(){

		//Si el score actual es mayor que el mejor score, se actualiza el mejor score
		if (totalScore > PlayerPrefs.GetInt("BestScore")) {
			PlayerPrefs.SetInt ("BestScore", totalScore);		
		}
	}
}
