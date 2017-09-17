using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


	//Función para iniciar el juego(cambio de escena)
	public void StartGame(){

		SceneManager.LoadScene ("Main");
	}
}
