using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Importamos la librería de publicidad
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

	public CoinsManager coinsManager;

	void Start(){

		DontDestroyOnLoad (gameObject);
		//Para vincular el id del juego a la hora de usar unityAds(Buscar el código en UnityAds dashboard)
		//Advertisement.Initialize ("gameId");
	}

	public void ShowAd(){

		//Si la publicidad está lista mostramos la publicidad y manejamos sus opciones
		if (Advertisement.IsReady()) {
			Advertisement.Show ("rewardedVideo",new ShowOptions(){resultCallback = HandleShowResult});
		}
	}

	void HandleShowResult(ShowResult result){

		switch (result) {
		//Si se termina de ver el video, se llama la función dentro del script "coinsManager" para agregar la recompensa
		case ShowResult.Finished:
			Debug.Log ("Felicidades haz conseguido una recompensa");
			coinsManager.AddCoins ();
			break;
		case ShowResult.Skipped:
			Debug.Log ("Tienes que ver el video para recibir la recompensa");
			break;
		case ShowResult.Failed:
			Debug.Log ("Error en la conexion a internet");
			break;
		}
	}
}
