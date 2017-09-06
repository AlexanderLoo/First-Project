using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private SpriteRenderer _sr;
	private Transform crosshair;

	void Start(){

		_sr = GetComponent<SpriteRenderer> ();
		crosshair = GameObject.Find ("Crosshair").transform;
	}

	void Update(){

		LookAtCrosshair ();
	}

	void LookAtCrosshair(){
		//Función para que el player mire hacia la mira
		if (crosshair.position.x < 0) {
			_sr.flipX = true;
		}
		if (crosshair.position.x > 0) {
			_sr.flipX = false;
		}
	}
}
