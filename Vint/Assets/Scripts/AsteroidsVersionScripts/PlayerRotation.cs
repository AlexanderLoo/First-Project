using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

	public VirtualJoystick aimJoystick;
	private Vector2 lastPos;

	void Update(){

		//Si se esta moviendo el aimJoystick
		if (aimJoystick.inputVector != Vector2.zero) {
			//Rotamos al player según el aimJoystick igualando su dirección de arriba
			Vector2 inputVector = aimJoystick.inputVector;
			transform.up = inputVector;
			lastPos = transform.up;
			//Caso contrario se deja en la última posición(esto evita que regrese al punto inicial)
		} else {
			transform.up = lastPos;
		}
	}
}
