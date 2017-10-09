using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour {

	//Paneles de opciones y compartir
	public GameObject optionPanel, sharePanel;
	//Booleanos que permiten controlar si se presionó o no los botones de opciones y compartir
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
}
