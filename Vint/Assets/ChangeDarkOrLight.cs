using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDarkOrLight : MonoBehaviour {

	//Este color oscuro equivale en RGB a 26,26,26
	private Color darkColor = new Color (0.1f, 0.1f, 0.1f);

	//Estas imagenes se encuentran en la escena principal
	public Image darkIcon, lightIcon;
	//Estas imagenes se encuentran en la escena del juego
	public Image[] inGamePanels;
	//Estas imagenes se encuentran en la escena de la tieneda
	public Image iapScreen;
	private Image fading;

	void Awake(){
		fading = GameObject.Find ("Fading").GetComponent<Image> ();

		//CÓDIGO IMPROVISADO POR FALTA DE TIEMPO, QUEDA PENDIENTE MEJORARLO 
		//accedemos a la memoria para obter el último tema usado
		if (PlayerPrefs.GetInt("BackgroundColor") == 1) {
			//Si encontramos los iconos del menu principal activamos o desactivamos las imagenes según el tema 
			if (darkIcon != null || lightIcon != null) {
				darkIcon.enabled = false;
				lightIcon.enabled = true;
			}//Si estamos en la escena de la tienda
			else if (iapScreen != null) {

				iapScreen.color = darkColor;
			}else {
				//en caso de no estar en el menu principal, asignamos el nuevo color a los diferentes paneles 
				foreach (Image panel in inGamePanels) {
					Color newColor = darkColor;
					//bajamos la opacidad del color(opcional)
					newColor.a = 0.6f;
					//Pequeña condición(opcional)...si el panel es "GameOverPanel" establecemos el color oscuro, si no el color oscuro con transparencia
					panel.color = (panel.gameObject.name == "GameOverPanel") ? darkColor : newColor;
				}
			}
			fading.color = darkColor;
			Camera.main.backgroundColor = darkColor;
		}
		//Lo mismo de arriba pero en caso que se guardó la version clara
		else if (PlayerPrefs.GetInt("BackgroundColor") == 0) {
			if (darkIcon != null || lightIcon != null) {
				darkIcon.enabled = true;
				lightIcon.enabled = false;
			} else if (iapScreen != null) {

				iapScreen.color = Color.white;
			}else {
				foreach (Image panel in inGamePanels) {
					Color newColor = Color.white;
					newColor.a =  0.6f;
					panel.color = (panel.gameObject.name == "GameOverPanel") ? Color.white : newColor;				}
			}
			fading.color = Color.white;
			Camera.main.backgroundColor = Color.white;
		}
	}

	public void ChangeTheme(){

		darkIcon.enabled = !darkIcon.enabled;
		lightIcon.enabled = !lightIcon.enabled;
		//Si el icono de luz esta activado cambiamos el color del fondo de la camara a un color oscuro
		if (lightIcon.enabled) {
			Camera.main.backgroundColor = darkColor;
			PlayerPrefs.SetInt ("BackgroundColor", 1);
		} else {
			//Caso contrario lo dejamos en blanco
			Camera.main.backgroundColor = Color.white;
			PlayerPrefs.SetInt ("BackgroundColor", 0);
		}
	}
}

