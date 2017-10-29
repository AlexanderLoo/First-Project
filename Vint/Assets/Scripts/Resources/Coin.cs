using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public float destroyTime;

	void OnEnable(){
		//Hacemos desaparecer la moneda después de un breve periodo de tiempo
		Invoke ("DestroyCoin",destroyTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		//Si el Player Colisiona con moneda, esta se desactiva y agregamos una moneda al total de monedas del player
		if (other.CompareTag("Player")) {
			DataManager.dataManager.CoinsManager (1);
			gameObject.SetActive (false);
		}
	}

	//Función para desactivar la moneda (QUEDA PENDIENTE DARLE EL EFECTO DE PARPADEO ANTES DE DESAPARECER)
	void DestroyCoin(){

		gameObject.SetActive (false);
	}

	void OnDisable(){
		CancelInvoke ("DestroyCoin");
	}
}
