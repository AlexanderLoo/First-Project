﻿using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject mobileController;
	public GameObject questionPanel;
	public GameObject[] confirmButton;	

	private Animator anim;

	void Awake(){

		anim = GetComponent<Animator> ();
	}

	public void PauseMenuPopup(){

		//Pausamos el juego y activamos el menu de pausa
		Time.timeScale = 0;
		mobileController.SetActive (false);
		pauseMenu.SetActive (true);
		//Activamos la animación del menu de pausa
		anim.SetTrigger ("inPause");

	}
	//Esta función permite activar el panel de confirmación
	public void QuestionPanelPopup(){

		questionPanel.SetActive (true);
		anim.SetTrigger ("questionPanel");
	}
	//Desactiva el panel de confirmación(cancelButton)
	public void DeactiveQuestionPanel(){
		//Este foreach sirve para desactivar todos los botones de confirmación que pueden estar activadas
		foreach (GameObject go in confirmButton) {
			go.SetActive (false);
		}
		questionPanel.SetActive (false);
	}

	public void ContinueGame(){

		//Establecemos el juego de nuevo y desactivamos el menu de pausa
		mobileController.SetActive (true);
		pauseMenu.SetActive (false);
		Time.timeScale = 1;
	}

	//LAS SIGUENTES FUNCIONES SE EJECUTAN CUANDO SE CONFIRMA LA ACCIÓN(botón de confirmación)
	public void RestartGame(){

		//Cargamos la escena nuevamente
		Time.timeScale = 1;
		SceneManager.LoadScene ("Main");
	}

	public void BackHomeScreen(){

		Time.timeScale = 1;
		SceneManager.LoadScene ("HomeScreen");
	}
	//función para salir del juego
	public void ExitGame(){

		Application.Quit ();
	}
	//LAS SIGUIENTES FUNCIONES ACTIVAN LOS BOTONES DE CONFIRMACIÓN

	public void ActiveConfirmRestartButton(){
		confirmButton[0].SetActive (true);
	}

	public void ActiveConfirmHomeScreenButton(){
		confirmButton[1].SetActive(true);
	}

	public void ActiveConfirmExitButton(){
		confirmButton[2].SetActive (true);
	}
}
