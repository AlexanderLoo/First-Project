using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour {

	private Transform crosshair;
	private SpriteRenderer playerSprite, weaponSprite;

	void Start(){

		crosshair = GameObject.Find ("Crosshair").transform;
		playerSprite = GameObject.Find ("Player").GetComponent<SpriteRenderer> ();
		weaponSprite = GameObject.FindGameObjectWithTag ("Weapon").GetComponent<SpriteRenderer> ();
	}

	void Update(){
		//Hacemos que la coordenada 'X' mire siempre hacia la mira
		transform.right = crosshair.position;
		FlippingWithPlayer ();
		ChangeOrderInLayer ();
	}

	void FlippingWithPlayer(){
		//Flipeamos el sprite del arma dependiendo donde este mirando el player
		weaponSprite.flipY = playerSprite.flipX;
	}

	void ChangeOrderInLayer(){
		//Función para poner el arma detrás del player si se esta apuntando hacia arriba
		//Modificamos el número de orden de la capa(sorting layer)
		if (crosshair.position.y > 0) {
			weaponSprite.sortingOrder = 0;
		}
		if (crosshair.position.y < 0) {
			weaponSprite.sortingOrder = 2;
		}
	}
}
