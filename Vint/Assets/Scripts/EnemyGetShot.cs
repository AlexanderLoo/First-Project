using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetShot : MonoBehaviour {

	//Declaramos una variable para tener acceso a la lista enemylist;
	private GameObject[] enemyPoolList;
	public bool bigSizeEnemy, normalSizeEnemy, smallSizeEnemy;

	void Awake(){

		enemyPoolList = GameObject.Find ("EnemyPool").GetComponent<EnemyPool> ().enemyList;
	}

	void OnTriggerEnter2D(Collider2D other){
		//Por el momento usamos el tag "Player" para detectar la bala
		if (other.CompareTag("Player")) {
			EnemySplit ();
			other.gameObject.SetActive (false);
			gameObject.SetActive (false);
		}
	}

	GameObject EnemySplit(){

		//Si el enemigo es de tamaño grande..recorremos la lista de enemigos y buscamos un enemigo de tamaño mediano y que este inactivo
		//Luego llamamos la función para activar el enemigo y retornamos el enemigo
		if (bigSizeEnemy) {
			for (int i = 0; i < enemyPoolList.Length; i++) {
				if (enemyPoolList [i].gameObject.GetComponent<EnemyGetShot> ().normalSizeEnemy && !enemyPoolList [i].activeSelf) {
					ActiveEnemy (i);
					return enemyPoolList [i];
				}
			}
		}
		if (normalSizeEnemy) {
			for (int i = 0; i < enemyPoolList.Length; i++) {
				if (enemyPoolList [i].gameObject.GetComponent<EnemyGetShot> ().smallSizeEnemy && !enemyPoolList [i].activeSelf) {
					ActiveEnemy (i);
					return enemyPoolList [i];
				}
			}
		}
		return null;
	}

	void ActiveEnemy(int i){

		enemyPoolList [i].SetActive (true);
		enemyPoolList [i].transform.position = transform.position;
		enemyPoolList [i].transform.rotation = transform.rotation;
	}
}
