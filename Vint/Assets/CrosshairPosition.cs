using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPosition : MonoBehaviour {


	void Update(){

		//Igualamos la posición de la mira con la posición del mouse en la pantalla
		Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = mousePos;
	}
}
