using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPosition : MonoBehaviour {

	public VirtualJoystick aimJoystick;
	public float aimRadius;

	void Update(){

		//Igualamos la posición de la mira con la posición del mouse en la pantalla
		/*Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = mousePos;*/
		CrosshairMovement ();
	}

	void CrosshairMovement(){
		//Obtenemos el inputVector de aimJoystick y lo normalizamos
		//Reposicionamos la mira según como se mueva el aimJoystick, regulamos con un aimRadius para ver que tan lejos esta la mira del player
		Vector2 movement = aimJoystick.inputVector;
		movement.Normalize ();
		//Otenemos la posición del player y le sumamos a nuestro vector movement para que su reposicionamiento sea relativo al del player
		Vector2 playerPos = transform.parent.position;
		transform.position = playerPos + movement * aimRadius;
			
	}
}
