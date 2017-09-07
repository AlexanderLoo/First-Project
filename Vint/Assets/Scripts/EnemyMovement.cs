using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	private Rigidbody2D _rb;
	private SpriteRenderer _sr;
	private Vector2 movement;

	public float speed;
	public float changePatrolTime;

	void Start(){

		_rb = GetComponent<Rigidbody2D> ();
		_sr = GetComponent<SpriteRenderer> ();
		InvokeRepeating ("MovementPatrol",0, changePatrolTime);
	}

	void Update(){

		_rb.velocity = movement * speed;
		FlippingSprite ();
	}


	void MovementPatrol(){

		//Dirección random en 'X' y en 'Y' con rango de -1,0,1
		int Xdirection = Random.Range (-1, 2);
		int Ydirection = Random.Range (-1, 2);
		movement = new Vector2 (Xdirection, Ydirection);
		movement.Normalize ();
	}

	void FlippingSprite(){

		//flipeamos el sprite del enemigo dependiendo a que dirección se mueve
		if (_rb.velocity.x > 0) {
			_sr.flipX = false;
		}
		if (_rb.velocity.x < 0) {
			_sr.flipX = true;
		}
	}
}
