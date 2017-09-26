using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D _rb;

	public float speed;
	public VirtualJoystick movementJoystick;		

	void Awake(){

		_rb = GetComponent<Rigidbody2D> ();
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
