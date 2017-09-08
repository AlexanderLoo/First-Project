using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {

	//Esta lista contiene los tipos de enemigos(según tamaño o raza)
	public GameObject[] enemiesTypes;
	//Lista total de enemigos en EnemyPool
	[System.NonSerialized]
	public GameObject[] enemyList;

	void Awake(){

		enemyList = new GameObject[30];
	}
	void Start(){
		
		//Por cada tipo de enemigo en la lista "enemiesTypes" agregamos una cantidad a nuestro EnemyPool
		foreach (GameObject enemyType in enemiesTypes) {
			for (int i = 0; i < enemyList.Length/3; i++) {

				GameObject newEnemy = (GameObject)Instantiate (enemyType);
				newEnemy.SetActive (false);
				enemyList [i] = newEnemy;
			}
		}
	}
}
