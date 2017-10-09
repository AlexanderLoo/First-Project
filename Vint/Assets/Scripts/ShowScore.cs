using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

	private Text scoreText;
	public int score;
	//booleano para definir si esta en juego o no
	public bool inGame;

	void Awake(){

		scoreText = GetComponent<Text> ();
	}

	void Start(){
		//Si no estamos en juego, se visualiza el mejor score
		if (!inGame) {
			scoreText.text = DataManager.dataManager.bestScore.ToString ();
		} else {
			score = 0;
			scoreText.text = score.ToString ();
		}
	}

	void Update(){

		if (inGame) {
			scoreText.text = score.ToString();
		}
	}
}
