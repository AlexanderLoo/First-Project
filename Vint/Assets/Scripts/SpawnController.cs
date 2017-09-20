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

		RightLeftSpawns ();
		TopButtonSpawns ();
		if (currentEnemiesCount == 0 ) {
			InvokeRepeating ("TopButtonSpawns", 0, 0);
			InvokeRepeating ("RightLeftSpawns", 0, 0);
		}

	}

	void TopButtonSpawns(){
		//El primer for recorre el spawn de arriba y luego el de abajo
		for (int i = 0; i < 2; i++) {
			//Este bucle for recorre los enemigos de la lista enemyPool
			for (int j = 0; j < enemyPool.enemyList.Length; j++) {
				//si el enemigo esta desactivado y no sobrepasamos el conteo máximo de enemigos que se quiere spawnear...
				if (!enemyPool.enemyList[j].activeSelf && currentEnemiesCount < maxEnemiesCount) {
					//Se Spawnea el enemigo en el spawn con coordenada 'X' aleatorio(dentro del rango límite establecido)
					Vector2 newPos = spawnPosList [i].transform.position;
					newPos.x = Random.Range (xLimits.x, xLimits.y);
					EnemySpawnManager (j, newPos);
				}
			}
			currentEnemiesCount = 0;

		
		}
	}
	void RightLeftSpawns(){
		//Misma lógica que la función de arriba con la diferencia que se usa los spawns de derecha e izquierda
		for (int i = 2; i < 4; i++) {
			for (int j = 0; j < enemyPool.enemyList.Length; j++) {
				if (!enemyPool.enemyList[j].activeSelf && currentEnemiesCount < maxEnemiesCount) {
					Vector2 newPos = spawnPosList [i].transform.position;
					//En este caso alteramos la coordenada 'Y' para que sea aleatoria
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

	

