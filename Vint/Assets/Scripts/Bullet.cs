using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform shotSpawn;
	public float speed;

	// OnEnable se ejecuta cada vez que la bala se activa
	void OnEnable () {
		shotSpawn = GameObject.Find ("ShotSpawn").transform;
		//accedemos al componente Rigidbody2D en la bala
		//y hacemos que su velocidad sea para arriba
		GetComponent<Rigidbody2D> ().velocity = shotSpawn.right * speed;
		//ejecutamos la funcion DestroyBullet 2 segundos despues de que la bala aparece
		Invoke("DestroyBullet", 2);
	}

	void DestroyBullet () {
		//desactivamos la bala
		gameObject.SetActive (false);
	}
}