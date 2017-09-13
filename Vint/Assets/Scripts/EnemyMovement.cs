using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	private Rigidbody2D _rb;
	private SpriteRenderer _sr;
	private Vector2 movement;
	private Transform playerPos;
	public bool playerDetected;
	public float speed;
	public float changePatrolTime;

	void Start(){

		_rb = GetComponent<Rigidbody2D> ();
		_sr = GetComponent<SpriteRenderer> ();
		playerPos = GameObject.Find ("Player").transform;
		InvokeRepeating ("MovementPatrol",0, changePatrolTime);
	}

	void OnEnable(){

		playerDetected = false;
	}

	void Update(){

		movement.Normalize ();
		_rb.velocity = movement * speed;
		FlippingSprite ();
	}


	void MovementPatrol(){

		//Si se detectó el player en el "EnemySensor", seguimos al player
		if (playerDetected) {
			Vector2 followPlayerVector = playerPos.position - transform.position;
			movement = followPlayerVector;
			//aumentamos el tiempo del patron de seguimiento y aumentamos la velocidad de movimiento
			changePatrolTime = 0.5f;
			speed = 3;
		} else {
			//Dirección random en 'X' y en 'Y' con rango de -1,0,1
			int Xdirection = Random.Range (-1, 2);
			int Ydirection = Random.Range (-1, 2);
			movement = new Vector2 (Xdirection, Ydirection);
		}
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
