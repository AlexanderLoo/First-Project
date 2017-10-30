using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D _rb;
	private VirtualJoystick movementJoystick;		
	private VirtualButton acelerationButton;
	public float speed;

	void Start(){

		_rb = GetComponent<Rigidbody2D> ();
		//Si no hay un objeto en escena con el nombre "MovemenBackgroundJoystick", buscamos la referencia del botón de aceleración
		if (GameObject.Find ("MovementBackgroundJoystick") == null) {
			acelerationButton = GameObject.Find ("AcelerationButton").GetComponent<VirtualButton> ();
		} else {
			//En caso que exista dicho nombre, lo asignamos
			movementJoystick = GameObject.Find ("MovementBackgroundJoystick").GetComponent<VirtualJoystick> ();
		}
	}

	void Update(){

		//Dependiendo que controles se esté usando, llamamos diferentes funciones
		if (movementJoystick != null) {
			PlayerMovementInMobile ();
		} else {
			if (acelerationButton.buttonPressed) {
				PlayerAceleration ();
			}
		}
	}

	void PlayerMovementInMobile(){

		Vector2 movement = movementJoystick.inputVector;
		movement.Normalize ();
		_rb.velocity = movement * speed;
	}

	void PlayerAceleration(){

		Vector2 movement = transform.up;
		_rb.AddForce(movement * speed);
		//Limitamos la velocidad para que no se agregue de mas y no tenga velocidad infinita
		if (_rb.velocity.magnitude > speed) {

			_rb.velocity = _rb.velocity.normalized * speed;
		}
	}

}
