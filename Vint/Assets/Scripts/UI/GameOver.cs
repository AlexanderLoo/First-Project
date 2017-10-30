using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public GameObject gameOverUI;
	public ShowScore currentScore;
	public GameObject mobileController;
	private Health playerHealth;



	void Start(){

		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<Health> ();
	}
	void Update(){
		//Si el player está muerto desactivamos los enemigos que siguen en la escena
		if (!playerHealth.alive) {

			Time.timeScale = 0;
			mobileController.SetActive (false);
			/*GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (GameObject enemy in enemies) {

				enemy.SetActive (false);
			}*/
			//Mostramos la ventana de Game Over
			gameOverUI.SetActive (true);
			//Mostramos el score alcanzado
			Text totalScore = GameObject.Find ("TotalScoreText").GetComponent<Text> ();
			totalScore.text = currentScore.score.ToString();
			//llamamos la función para actualizar el mejor score
			DataManager.dataManager.UpdateBestScore (currentScore.score);
		}
	}

}
