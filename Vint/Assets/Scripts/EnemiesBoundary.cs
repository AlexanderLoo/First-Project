using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBoundary : MonoBehaviour {

	//Esta variable sirve para expandir el tamaño del collider
	public Vector2 addMoreScale = new Vector2(1,1);
	private SpawnController spawnController;

	void Start(){

		spawnController = GetComponentInParent<SpawnController> ();
		//Se multiplica por dos para que encaje con el tamaño de la pantalla
		Vector2 newSize = new Vector2 (GetScreenSize.screenSize.maxInX * 2 * addMoreScale.x, GetScreenSize.screenSize.maxInY * 2 * addMoreScale.y);
		transform.localScale = newSize;
	}

	void OnTriggerExit2D(Collider2D other){

		//si un enemigo sale del trigger, restamos el conteo de enemigos activos y lo desactivamos el enemigo
		if (other.CompareTag("Enemy")) {

			spawnController.activeEnemies--;
			other.gameObject.SetActive (false);
		}
	}
}