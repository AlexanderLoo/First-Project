using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D _rb;
	private VirtualJoystick movementJoystick;		

	public float speed;

	void Start(){

		_rb = GetComponent<Rigidbody2D> ();
		movementJoystick = GameObject.Find ("MovementBackgroundJoystick").GetComponent<VirtualJoystick> ();
	}

	void Update(){

		PlayerMovementInMobile ();
	}

	void PlayerMovementInMobile(){

		Vector2 movement = movementJoystick.inputVector;
		movement.Normalize ();
		_rb.velocity = movement * speed;
	}

}
