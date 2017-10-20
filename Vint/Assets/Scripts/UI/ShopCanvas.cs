using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopCanvas : MonoBehaviour {

	public ArtStyles[] artStyles;
	public Text[] nameText;
	public Text[] costText;


	public Scrollbar _scrollBar;
	public float valueController, smoothing;
	private float finalValue;
	private ShowCoins showCoins;

	void Awake(){
		//Al iniciar la escena asignamos cada item con sus respectivos nombres y costos
		for (int i = 0; i < nameText.Length; i++) {
			nameText [i].text = artStyles [i].name;
		}
		for (int j = 0; j < costText.Length; j++) {
			costText [j].text = artStyles [j].cost.ToString();
		}
		showCoins = GameObject.Find ("TotalCoinsText").GetComponent<ShowCoins> ();
	}
	//Si se presiona el botón derecho scrolleamos un valor definido hacia la derecha
	public void RightButtonPressed(){

		finalValue = _scrollBar.value + valueController;
	}

	//Del mismo modo hacia la izquierda
	public void LeftButtonPressed(){

		finalValue = _scrollBar.value - valueController;
	}

	public void BackHomeScreen(){

		SceneManager.LoadScene ("HomeScreen");
	}

	void Update(){

		_scrollBar.value = Mathf.Lerp (_scrollBar.value, finalValue, Time.deltaTime * smoothing);

	}

	//***********FUNCIONES PARA COMPRAR ITEMS*************(CÓDIGO IMPROVISADO, EN ESPERA DE SUGERENCIAS) =)
	public void FirstItem(){

		//Comparamos si tenemos monedas suficiente para comprar el item 
		if (DataManager.dataManager.totalCoins >= artStyles [0].cost) {
			//Si es asi, llamamos la función CoinsManager(dentro de DataManager) para descontar las monedas
			DataManager.dataManager.CoinsManager (-artStyles [0].cost);
			//por el momento "equipamos" el diseño y actualizamos las monedas totales
			PlayerPrefs.SetInt ("CurrentArtStyle", 0);
			showCoins.UpdateTotalCoins ();
		} else {
			print ("No tienes suficientes monedas =(");
			//SE PIENSA REMPLAZAR ESTA ÚLTIMA LÍNEA CON UN MOLESTO SCREEN DE UN DESCUENTO EN LOTES DE MONEDAS XD
		}
	}
	public void SecondItem(){

		if (DataManager.dataManager.totalCoins >= artStyles [1].cost) {

			DataManager.dataManager.CoinsManager (-artStyles [1].cost);
			PlayerPrefs.SetInt ("CurrentArtStyle", 1);
			showCoins.UpdateTotalCoins ();
		} else {
			print ("No tienes suficientes monedas =(");
		}
	}
}
