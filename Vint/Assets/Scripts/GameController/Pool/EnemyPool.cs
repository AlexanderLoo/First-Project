using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {

	//Esta lista contiene los tipos de enemigos(según tamaño o raza)
	public GameObject[] enemiesTypes;
	//Lista total de enemigos en EnemyPool
	[System.NonSerialized]
	public GameObject[] enemyList;


	void Start(){

		enemyList = new GameObject[45];
	
		for (int i = 0; i < 15; i++) {
			GameObject newEnemy = (GameObject)Instantiate (enemiesTypes [0]);
			newEnemy.SetActive (false);
			enemyList [i] = newEnemy;
		}
		for (int i = 15; i < 30; i++) {
			GameObject newEnemy = (GameObject)Instantiate (enemiesTypes [1]);
			newEnemy.SetActive (false);
			enemyList [i] = newEnemy;
		}
		for (int i = 30; i < 45; i++) {
			GameObject newEnemy = (GameObject)Instantiate (enemiesTypes [2]);
			newEnemy.SetActive (false);
			enemyList [i] = newEnemy;
		}
	}
}
