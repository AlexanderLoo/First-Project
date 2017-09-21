using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour {

	//Paneles de opciones y compartir
	public GameObject optionPanel, sharePanel;
	//referencia a musicController
	public AudioSource music;
	private bool optionButtonPressed, shareButtonPressed;

	//Función para iniciar el juego(cambio de escena)
	public void StartGame(){

		SceneManager.LoadScene ("Main");
	}

	//función para desplegar el optionPanel
	public void OptionButtonManager(){

		optionPanel.SetActive (!optionButtonPressed);
		optionButtonPressed = !optionButtonPressed;
	}
	//función para desplegar sharePanel
	public void ShareButtonManager(){

		sharePanel.SetActive (!shareButtonPressed);
		shareButtonPressed = !shareButtonPressed;
	}
	//función para silenciar la música
	public void MuteMusic(){

		music.mute = !music.mute;
	}



}
