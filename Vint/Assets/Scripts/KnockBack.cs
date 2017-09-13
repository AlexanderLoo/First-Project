using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour {

	private Rigidbody2D _rb;
	private Shooting _shot;
	private GameObject _mainCamera; 

	public float knockBackForce;

	void Start(){

		_rb = GetComponent<Rigidbody2D> ();
		_shot = GetComponentInChildren<Shooting> ();
		_mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void Update(){

		//Si se dispara se agrega fuerza física al lado contrario del eje 'X' del arma
		if (_shot.shot) {
			_rb.AddForce (-_shot.transform.right * knockBackForce);
			//activar temblor
			_mainCamera.GetComponent<CameraShake> ().enabled = true;
		} else {
			//desactivar temblor
			_mainCamera.GetComponent<CameraShake> ().enabled = false;
		}
	}
}
