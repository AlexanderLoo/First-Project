using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetShot : MonoBehaviour {

	//Declaramos una variable para tener acceso a la lista enemylist;
	private GameObject[] enemyPoolList;
	//Esta variable sirve para setear la cantidad de divisiones que va tener el enemigo
	private int enemiesNum = 0, maxEnemiesNum = 2;
	public bool bigSizeEnemy, normalSizeEnemy, smallSizeEnemy;

	void Awake(){

		enemyPoolList = GameObject.Find ("EnemyPool").GetComponent<EnemyPool> ().enemyList;
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.CompareTag("Bullet")) {
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
					//Cada vez que se llame a esta función, hacemos un conteo..
					enemiesNum += 1;
					//si el conteo llega a la cantidad Máxima(cantidad de enemigos que se van a crear)..reseteamos el contador e interrumpimos el bucle para que deje de buscar
					if (enemiesNum == maxEnemiesNum) {
						enemiesNum = 0;
						break;
					}
				}
			}
		}
		if (normalSizeEnemy) {
			for (int i = 0; i < enemyPoolList.Length; i++) {
				if (enemyPoolList [i].gameObject.GetComponent<EnemyGetShot> ().smallSizeEnemy && !enemyPoolList [i].activeSelf) {
					ActiveEnemy (i);
					enemiesNum += 1;
					if (enemiesNum == maxEnemiesNum) {
						enemiesNum = 0;
						break;
					}
				}
			}
		}
		return null;
	}
	//Esta función activa el enemigo y lo posiciona en el transform.position
	GameObject ActiveEnemy(int i){

		enemyPoolList [i].SetActive (true);
		enemyPoolList [i].transform.position = transform.position;
		enemyPoolList [i].transform.rotation = transform.rotation;
		return enemyPoolList [i];
	}
}
