using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Importamos la librería de publicidad
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {
	
	public GameObject rewardImage;

	/*public static AdManager ads;

	void Awake(){
		
		if (ads == null) {
			DontDestroyOnLoad (gameObject);
			ads = this;
		}
		else if (ads != this) {

			Destroy (gameObject);
		}
	}*/

	void Start(){

		//Para vincular el id del juego a la hora de usar unityAds(Buscar el código en UnityAds dashboard)
		//Advertisement.Initialize ("gameId");

	}
	//Lógica temporal(Se espera sugerencias)
	void Update(){

		if (Advertisement.IsReady()) {
			rewardImage.SetActive (true);
		} else {
			rewardImage.SetActive (false);
		}
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
			//Si se termina de ver el video se recompensa al jugador con 1 moneda
			DataManager.dataManager.CoinsManager (1);
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
