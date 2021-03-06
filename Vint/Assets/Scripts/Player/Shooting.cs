﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	
	public Transform shotSpawn;
	public bool shot;
	public float fireRate;
	//esta es la bala que vamos a crear
	public GameObject bulletPrefab;
	//este es el pool de donde vamos a sacar las balas
	private BulletsPool bulletsPool;
	private VirtualJoystick onDragAimJoystick;
	private VirtualButton fireButton;
	private AudioSource _as;

	void Start () {

		bulletsPool = GameObject.Find ("BulletPool").GetComponent<BulletsPool> ();
		onDragAimJoystick = GameObject.Find ("AimBackgroundJoystick").GetComponent<VirtualJoystick> ();
		_as = GetComponent<AudioSource> ();
		if (GameObject.Find ("FireButton") != null) {
			fireButton = GameObject.Find ("FireButton").GetComponent<VirtualButton> ();
		} 
		InvokeRepeating ("CreateBullet", 0, fireRate);
	}
		
	void Update () {

		if (onDragAimJoystick.spaceController == false) {
			IsShooting ();
		} else {
			shot = fireButton.buttonPressed;
		}
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
			//Reproducimos el sonido de disparo
			_as.Play();
		}
	}

}


