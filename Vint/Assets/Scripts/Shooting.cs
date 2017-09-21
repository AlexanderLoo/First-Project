using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	
	//este es el pool de donde vamos a sacar las balas
	public BulletsPool bulletsPool;
	public Transform shotSpawn;
	[System.NonSerialized]
	public bool shot;
	//esta es la bala que vamos a crear
	public GameObject bulletPrefab;
	public VirtualJoystick onDragAimJoystick;

	void Start () {

		InvokeRepeating ("CreateBullet", 0, 0.1f);
	}
		
	void Update () {
		
		IsShooting ();
	}

	void IsShooting(){

		//Si tenemos movimiento en el aimJoystick, disparamos
		if (onDragAimJoystick.inputVector != Vector2.zero){
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


