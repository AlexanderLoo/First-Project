﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject _Crosshair;

	public void PauseMenuPopup(){

		//Pausamos el juego y activamos el menu de pausa
		Time.timeScale = 0;
		pauseMenu.SetActive (true);
		_Crosshair.GetComponent<CrosshairPosition> ().enabled = false;


	}

	public void ContinueGame(){

		//Establecemos el juego de nuevo y desactivamos el menu de pausa
		Time.timeScale = 1;
		pauseMenu.SetActive (false);
		_Crosshair.GetComponent<CrosshairPosition> ().enabled = true; 
	}
}
