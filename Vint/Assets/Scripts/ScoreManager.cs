using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private Text scoreText;
	public int totalScore;

	void Awake(){

		scoreText = GetComponentInChildren<Text> ();
	}

	void Start(){

		scoreText.text = "Score: 0";
	}

	void Update(){
		//Actualizamos el score total en el scoreText
		scoreText.text = "Score: " + totalScore.ToString();
	}

}
