using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	
	//este es el pool de donde vamos a sacar las balas
	private BulletsPool bulletsPool;
	private Transform shotSpawn;
	[System.NonSerialized]
	public bool shot;
	//esta es la bala que vamos a crear
	public GameObject bulletPrefab;


	void Start () {

		bulletsPool = GameObject.Find (bulletPrefab.name + "Pool").GetComponent<BulletsPool> ();
		shotSpawn = GameObject.Find ("ShotSpawn").transform;
		InvokeRepeating ("CreateBullet", 0, 0.1f);
	}
		
	void Update () {
		
		if (Input.GetButton("Fire1")){
			shot = true;
		} else {
			shot = false;
		}
	}

	//esta funcion crea una bala
	void CreateBullet(){
		
		if (shot) {
			bulletsPool.SpawnBullets (shotSpawn.position, shotSpawn.rotation);
		}
	}
}


