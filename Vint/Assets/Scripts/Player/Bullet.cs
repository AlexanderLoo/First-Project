using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform shotSpawn;
	private Rigidbody2D _rb;
	public float speed = 10;

	// OnEnable se ejecuta cada vez que la bala se activa
	void OnEnable () {

		shotSpawn = GameObject.Find ("ShotSpawn").transform;

		_rb = GetComponent<Rigidbody2D> ();
		_rb.velocity = shotSpawn.right * speed;

		//ejecutamos la funcion DestroyBullet 'n' segundos despues de que la bala aparece
		Invoke("DestroyBullet", 3);
	}

	void DestroyBullet () {
		//desactivamos la bala
		gameObject.SetActive (false);
	}

	void OnDisable(){

		CancelInvoke ("DestroyBullet");
	}
}