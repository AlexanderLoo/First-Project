using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour {

	private Rigidbody2D _rb;
	private SpriteRenderer _sr;
	private Shooting _shot;

	public float knockBackForce;

	void Start(){

		_rb = GetComponent<Rigidbody2D> ();
		_sr = GetComponent<SpriteRenderer> ();
		_shot = GetComponentInChildren<Shooting> ();
	}

	void Update(){

		//Si se dispara se agrega fuerza física al lado contrario del eje 'X' del arma
		if (_shot.shot) {
			_rb.AddForce (-_shot.transform.right * knockBackForce);
		}
	}
}
