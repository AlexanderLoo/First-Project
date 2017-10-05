using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour {

	public Text totalCoins;
	private int coinsCount;
	
	void Start(){

		DontDestroyOnLoad (gameObject);
		coinsCount = PlayerPrefs.GetInt ("TotalCoins");

		//lo imprimimos en el texto "TotalCoins"
		SetTotalCoinsInText ();
	}

	public void AddCoins(){
		//Al ser llamada esta función agregamos la recompensa a la memoria y lo imprimimos en el texto "TotalCoins"
		coinsCount++;
		PlayerPrefs.SetInt ("TotalCoins", coinsCount);
		SetTotalCoinsInText ();
	}

	//FUNCIÓN TEMOPRAL PARA TESTEO
	void SetTotalCoinsInText(){

		if (totalCoins == null) {
			return;
		} else {
			totalCoins.text = coinsCount.ToString ();
		}
	}
}
