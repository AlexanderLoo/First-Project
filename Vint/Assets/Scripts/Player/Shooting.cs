using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	
	public Transform shotSpawn;
	[System.NonSerialized]
	public bool shot;
	public float fireRate;
	//esta es la bala que vamos a crear
	public GameObject bulletPrefab;
	//este es el pool de donde vamos a sacar las balas
	private BulletsPool bulletsPool;
	private VirtualJoystick onDragAimJoystick;

	void Start () {

		bulletsPool = GameObject.Find ("BulletPool").GetComponent<BulletsPool> ();
		onDragAimJoystick = GameObject.Find ("AimBackgroundJoystick").GetComponent<VirtualJoystick> ();
		InvokeRepeating ("CreateBullet", 0, fireRate);
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


