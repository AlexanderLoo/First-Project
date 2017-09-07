using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour {

	public EnemyMovement enemyMovementScript;

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag("Player")) {
			enemyMovementScript.playerDetected = true;
		}
	}
}
