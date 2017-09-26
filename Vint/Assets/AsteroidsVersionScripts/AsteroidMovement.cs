using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

	private Rigidbody2D _rb;
	public float speed;

	void Awake(){

		_rb = GetComponent<Rigidbody2D> ();
	}

	void OnEnable(){
		//Al activar el enemigo le damos una rotación aleatoria
		Quaternion newRotation = Quaternion.Euler(0, 0, Random.Range (0, 360));
		transform.rotation = newRotation;
		_rb.velocity = transform.up * speed;
	}
}
