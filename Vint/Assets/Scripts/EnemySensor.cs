using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour {

	private EnemyMovement enemyMovementScript;

	void Awake(){

		enemyMovementScript = GetComponentInParent<EnemyMovement> ();
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag("PlayerSensor")) {
			enemyMovementScript.playerDetected = true;
		}
	}
}
