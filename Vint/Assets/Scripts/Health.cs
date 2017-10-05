using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public bool alive;

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag("Enemy")) {
			alive = false;
		}
	}
}
