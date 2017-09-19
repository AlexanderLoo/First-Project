using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private SpriteRenderer _sr;
	private Rigidbody2D _rb;
	private Transform crosshair;

	public float speed;

	public VirtualJoystick movementJoystick, aimJoystick;

	void Awake(){

		_sr = GetComponent<SpriteRenderer> ();
		_rb = GetComponent<Rigidbody2D> ();
		crosshair = GameObject.Find ("Crosshair").transform;
	}

	void Update(){

		/*float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		PlayerMovement (h,v);*/
		PlayerMovementInMobile ();
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

	/*void PlayerMovement(float h, float v){

		Vector2 movement = new Vector2 (h, v);
		movement.Normalize ();
		_rb.velocity = movement * speed;
	}*/

	void PlayerMovementInMobile(){

		Vector2 movement = movementJoystick.inputVector;
		movement.Normalize ();
		_rb.velocity = movement * speed;
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
