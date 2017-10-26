using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {



	//lista de los spawns top:0, bottom:1, right:2, left:3
	public GameObject[] spawnPosList;
	public EnemyPool enemyPool;
	public int maxEnemiesCount;
	//Esta variable cuenta los enemigos activos(la antigua variable "enemyCount")
	public int activeEnemies;
	public int startWaveNum = 3;
	public int RatioWave = 10;
	private int currentEnemiesCount;
	public ShowScore _showScore;

	private Health playerHealth;

	void Start(){

		_showScore = GameObject.Find ("ScoreText").GetComponent<ShowScore> ();
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<Health> ();
		InvokeRepeating ("TopWave", startWaveNum, RatioWave);
		InvokeRepeating ("RightWave", startWaveNum + 3, RatioWave);

	}

	void Update(){
		if (_showScore.score > 1) {
			Debug.Log ("Hols");
			RatioWave = 1;
		}
	}

	void TopButtonSpawns(){
		//El primer for recorre el spawn de arriba y luego el de abajo
		for (int i = 0; i < 2; i++) {
			//Este bucle for recorre los enemigos de la lista enemyPool
			//El valor de j permite recorrer la lista de forma aleatoria(para evitar spawnear primero los enemigos grandes, sino de forma aleatoria)
			for (int j = Random.Range(0,enemyPool.enemyList.Length); j < enemyPool.enemyList.Length; j++) {
				//si el enemigo esta desactivado y no sobrepasamos el conteo máximo de enemigos que se quiere spawnear...
				if (!enemyPool.enemyList[j].activeSelf && currentEnemiesCount < maxEnemiesCount) {
					//Se Spawnea el enemigo en el spawn con coordenada 'X' aleatorio(dentro del rango límite establecido)
					Vector2 newPos = spawnPosList [i].transform.position;
					newPos.x = Random.Range (-GetScreenSize.screenSize.maxInX, GetScreenSize.screenSize.maxInX);
					EnemySpawnManager (j, newPos);
				}
			}
			currentEnemiesCount = 0;
		}
	}

	void RightLeftSpawns(){
		//Misma lógica que la función de arriba con la diferencia que se usa los spawns de derecha e izquierda
		for (int i = 2; i < 4; i++) {
			for (int j = Random.Range(0,enemyPool.enemyList.Length); j < enemyPool.enemyList.Length; j++) {
				if (!enemyPool.enemyList[j].activeSelf && currentEnemiesCount < maxEnemiesCount) {
					Vector2 newPos = spawnPosList [i].transform.position;
					//En este caso alteramos la coordenada 'Y' para que sea aleatoria
					newPos.y = Random.Range (-GetScreenSize.screenSize.maxInY, GetScreenSize.screenSize.maxInY);
					EnemySpawnManager (j, newPos);
				}
			}
			currentEnemiesCount = 0;
		}
	}

	void EnemySpawnManager(int j, Vector2 newPos){

		enemyPool.enemyList [j].transform.position = newPos;
		enemyPool.enemyList [j].SetActive (true);
		currentEnemiesCount++;
		activeEnemies++;
	}



	//*******Las siguientes funciones manejan los waves***********

//	void BasicWave(){
//
//		if (playerHealth.alive) {
//			RightLeftSpawns ();
//			TopButtonSpawns ();
//		}
//
//	}

	void TopWave(){

		if (playerHealth.alive) {
			TopButtonSpawns ();
		}

	}
	void RightWave(){

		if (playerHealth.alive) {
			RightLeftSpawns ();

		}

	}

	//*****CREAR NUEVAS IDEAS DE WAVES ACÁ********
	//void ....
}


	

