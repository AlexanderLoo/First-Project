using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScreenSize : MonoBehaviour {

	public float  maxInX, maxInY;

	void Awake(){

		//Accedemos al tamaño del alto y el ancho de la pantalla(cualquier resolución) y lo guardamos en un Vector2
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		Vector2 screenSize = new Vector2 (screenWidth, screenHeight);
		//Convertimos el tamaño de la pantalla(pixels) en el tamaño en medidas del mundo
		Vector2 newSize = Camera.main.ScreenToWorldPoint (screenSize);
		//Obtenemos los límites en los ejes X y Y (los valores mínimos serian los mismos valores en negativo)
		maxInX = newSize.x;
		maxInY = newSize.y;
	}
}
