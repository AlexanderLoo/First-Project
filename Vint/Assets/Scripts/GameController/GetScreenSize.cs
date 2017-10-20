using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScreenSize : MonoBehaviour {

	public static GetScreenSize screenSize;
	public float  maxInX, maxInY;

	void Awake(){

		if (screenSize == null) {
			DontDestroyOnLoad (gameObject);
			screenSize = this;
		}
		else if (screenSize != this) {
			Destroy (gameObject);
		}

		//Accedemos al tamaño del alto y el ancho de la pantalla(cualquier resolución) y lo guardamos en un Vector2
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		Vector2 screenSizeVector = new Vector2 (screenWidth, screenHeight);
		//Convertimos el tamaño de la pantalla(pixels) en el tamaño en medidas del mundo
		Vector2 newSize = Camera.main.ScreenToWorldPoint (screenSizeVector);
		//Obtenemos los límites en los ejes X y Y (los valores mínimos serian los mismos valores en negativo)
		maxInX = newSize.x;
		maxInY = newSize.y;
	}
}
