﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipManager : MonoBehaviour {

	private SpriteRenderer _sr;
	private Transform crosshair;

	private VirtualJoystick movementJoystick, aimJoystick;

	void Start(){

		_sr = GetComponent<SpriteRenderer> ();
		crosshair = GameObject.Find ("Crosshair").transform;
		movementJoystick = GameObject.Find ("MovementBackgroundJoystick").GetComponent<VirtualJoystick> ();
		aimJoystick = GameObject.Find ("AimBackgroundJoystick").GetComponent<VirtualJoystick> ();

	}

	void Update(){

		//SÓLO SI NO HAY INPUTS EN EL AIMJOYSTICK
		//Flipeamos el sprite del player según hacia que dirección caminemos(movementJoystick)
		if (aimJoystick.inputVector == Vector2.zero) {
			FlippingWithMovement ();
		//Si no siempre miramos hacia la mira
		} else {
			LookAtCrosshair ();
		}
	}

	void LookAtCrosshair(){

		//Función para que el player mire hacia la mira
		if (crosshair.position.x < transform.position.x) {
			_sr.flipX = true;
		}
		if (crosshair.position.x > transform.position.x) {
			_sr.flipX = false;
		}
	}

	void FlippingWithMovement(){
		
		if (movementJoystick.inputVector.x > 0) {
			_sr.flipX = false;
		}
		if (movementJoystick.inputVector.x < 0) {
			_sr.flipX = true;
		}
	}
}
