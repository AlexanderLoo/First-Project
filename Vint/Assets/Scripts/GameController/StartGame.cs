using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
	
	//Este script maneja bugs imprevistos(un poco dificiles de arreglar por el momento)
	void Start(){
		//nos aseguramos que el tiempo sea normal al iniciar el juego
		Time.timeScale = 1;
		//nos aseguramos que si en otra escena esta muteado..en esta escena también lo este
		if (PlayerPrefs.GetInt("UseSound") != 1) {
			Camera.main.GetComponent<AudioListener> ().enabled = false;
		}
	}
}
