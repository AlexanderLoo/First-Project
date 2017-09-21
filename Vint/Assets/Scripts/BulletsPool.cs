using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour {
	
	public GameObject bulletPrefab;
	private GameObject[] bulletList;

	void Awake () {
		
		//creamos nuestro arreglo y fijamos la cantidad de elementos que tendrá
		bulletList = new GameObject[25];

		for (int i = 0; i < bulletList.Length; i++) {
			//creamos la bala
			GameObject newBullet = (GameObject) Instantiate (bulletPrefab);
			//desactivamos la bala
			newBullet.SetActive (false);
			//colocamos la bala dentro del arreglo
			bulletList [i] = newBullet;
		}
	}

	//esta funcion se encarga de que la bala aparezca
	public GameObject SpawnBullets(Vector2 pos, Quaternion rot){
		
		for (int i = 0; i < bulletList.Length; i++) {
			//preguntamos si esta copia de la bala esta apagada
			if (bulletList[i].activeSelf == false) {
				
				bulletList [i].SetActive (true);
				//colocamos la copia en la posicion que recibimos como parametro
				bulletList [i].transform.position = pos;
				//igual hacemos con la rotacion
				bulletList [i].transform.rotation = rot;
				//retornamos como resultado la copia
				return bulletList [i];
			}
		}
		//si todas las copias estan siendo usadas... retornamos nulo
		return null;
	}
}
