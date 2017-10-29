using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

	public static DataManager dataManager;
	public int bestScore, totalCoins;

	private AudioSource _as;

	void Awake(){

		if (dataManager == null) {
			//Si dataManager no ha sido asignado, no lo destruimos al cambio de escena y lo asignamos con ESTE SCRIPT
			DontDestroyOnLoad (gameObject);
			dataManager = this;
		}
		else if (dataManager != this) {
			Destroy (gameObject);
		}
		//Obtenemos el mejor score y las monedas totales guardadas en la memoria
		bestScore = PlayerPrefs.GetInt("BestScore");
		totalCoins = PlayerPrefs.GetInt ("TotalCoins");
		_as = GetComponent<AudioSource> ();
	}

	public void UpdateBestScore(int score){

		//Si el score es mayor que el mejor score, actualizamos los datos en la memoria
		if (score > bestScore) {

			PlayerPrefs.SetInt ("BestScore", score);
			bestScore = PlayerPrefs.GetInt("BestScore");
		}
	}
	//Función para administrar las monedas(se puede adicionar o sustraer)
	public void CoinsManager(int coins){

		totalCoins += coins;
		//Para asegurarnos que la cantidad exacta se guarde en la memoria
		PlayerPrefs.SetInt ("TotalCoins", totalCoins);
		totalCoins = PlayerPrefs.GetInt ("TotalCoins");
		//Reproducimos el audio de recompensa(moneda recolectada)
		_as.Play ();
	}
}