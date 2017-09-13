using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	//lista de los spawns top:0, button:1, right:2, left:3
	public GameObject[] spawnPosList;
	public EnemyPool enemyPool;
	public int maxEnemiesCount;
	private int currentEnemiesCount;
	private AdjustSpawnsPosition adjustSpawnsPos;
	//creamos 2 Vector2 para manejar de forma mas rápida los límites en eje X y Y
	private Vector2 xLimits, yLimits;

	void Start(){

		adjustSpawnsPos = GetComponent<AdjustSpawnsPosition> ();
		//asignamos los límites de pantalla encontrados en el script "AdjustSpawnsPosition" de ambas coordenadas
		xLimits = new Vector2 (adjustSpawnsPos.minInX, adjustSpawnsPos.maxInX);
		yLimits = new Vector2 (adjustSpawnsPos.minInY, adjustSpawnsPos.maxInY);
		TopButtonSpawns ();
		RightLeftSpawns ();
	}
	//SUERTE!
	void TopButtonSpawns(){

		for (int i = 0; i < 2; i++) {
			for (int j = 0; j < enemyPool.enemyList.Length; j++) {
				if (!enemyPool.enemyList[j].activeSelf && currentEnemiesCount < maxEnemiesCount) {
					Vector2 newPos = spawnPosList [i].transform.position;
					newPos.x = Random.Range (xLimits.x, xLimits.y);
					EnemySpawnManager (j, newPos);
				}
			}
			currentEnemiesCount = 0;
		}
	}
	void RightLeftSpawns(){

		for (int i = 2; i < 4; i++) {
			for (int j = 0; j < enemyPool.enemyList.Length; j++) {
				if (!enemyPool.enemyList[j].activeSelf && currentEnemiesCount < maxEnemiesCount) {
					Vector2 newPos = spawnPosList [i].transform.position;
					newPos.y = Random.Range (yLimits.x, yLimits.y);
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
	}
}

	

