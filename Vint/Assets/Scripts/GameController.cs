using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public ScoreManager scoreManager;
	public GameObject gameOverCanvas;
	public Health playerHealth;

	void Update(){

		if (!playerHealth.alive) {
			HighScore ();
			gameOverCanvas.SetActive (true);
		}
	}

	void HighScore(){

		//Si el score total es mayor que el mejor score, se actualiza el mejor score
		if (scoreManager.totalScore > PlayerPrefs.GetInt("BestScore")) {
			PlayerPrefs.SetInt ("BestScore", scoreManager.totalScore);
		}
	}
}
