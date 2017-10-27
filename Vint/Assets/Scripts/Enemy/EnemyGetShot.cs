using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGetShot : MonoBehaviour {

	//Declaramos una variable para tener acceso a la lista enemylist;
	private GameObject[] enemyPoolList;
	private ShowScore showScore;
	private CoinPool coinPool;
	private CoinDrop coinDrop;
	//Esta variable sirve para setear la cantidad de divisiones que va tener el enemigo
	public int enemiesNum = 0, maxEnemiesNum = 2;
	public bool bigSizeEnemy, normalSizeEnemy, smallSizeEnemy;
	private SpawnController _spawnController;


	void Awake(){

		enemyPoolList = GameObject.Find ("EnemyPool").GetComponent<EnemyPool> ().enemyList;
		showScore = GameObject.Find ("ScoreText").GetComponent<ShowScore> ();
		_spawnController = GameObject.Find ("SpawnController").GetComponent<SpawnController> ();
		coinPool = GameObject.Find ("CoinPool").GetComponent<CoinPool> ();
		coinDrop = GetComponent<CoinDrop> ();


	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag("Bullet")) {
			EnemySplit ();
			other.gameObject.SetActive (false);
			AddScore ();
			//Dropeamos una moneda si tenemos suerte
			if (coinDrop.coinDrop) {
				coinPool.SpawnCoins (transform.position);
			}
			gameObject.SetActive (false);
			//restamos el conteo de enemigos activados
			_spawnController.activeEnemies--;
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
		_spawnController.activeEnemies++;
		return enemyPoolList [i];
	}

	//Función que se encarga de dar puntaje al player según el tipo de enemigo
	void AddScore(){

		int score;

		if (bigSizeEnemy) {
			score = 10;
		} else if (normalSizeEnemy) {
			score = 20;
		} else {
			score = 50;
		}
		showScore.score += score;
	}
}
