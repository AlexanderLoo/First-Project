using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	private SpriteRenderer _sr;
	private Rigidbody2D _rb;
	private Transform crosshair;

	public float speed;

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
		LookAtCrosshair ();
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

		Vector2 movement = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),CrossPlatformInputManager.GetAxis("Vertical"));
		movement.Normalize ();
		_rb.velocity = movement * speed;
	}
}
