using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject gameOverCanvas;
	public Text bestScoreText;
	public Health playerHealth;

	void Start(){

		if (gameOverCanvas == null) {
			return;
		}
	}

	void Update(){
		//PREGUNGAR AL PROFE SI ES EFICIENTE USAR PLAYERPREFS DENTRO DEL UPDATE
		//PREGUNTAR TAMBIÉN SI FIND() TAMBIEN BUSCA GAMEOBJECTS DESACTIVADOS
		//PREGUNTAR COMO COMPARTIR GAMEOBJECTS EN DIFERENTES ESCENAS
		bestScoreText.text = PlayerPrefs.GetInt ("BestScore").ToString ();
		if (!playerHealth.alive) {
			gameOverCanvas.SetActive (true);
		}
	}
	//Función para iniciar el juego(cambio de escena)
	public void StartGame(){

		SceneManager.LoadScene ("Main");
	}
}
