using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour {

	public Transform crosshair;
	public SpriteRenderer playerSprite;

	private SpriteRenderer weaponSprite;

	void Awake(){

		weaponSprite = GameObject.FindGameObjectWithTag ("Weapon").GetComponent<SpriteRenderer> ();
	}

	void Update(){
		//Hacemos que la coordenada 'X' mire siempre hacia la mira
		Vector2 newVector = crosshair.position - transform.position;
		transform.right = newVector;
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
		if (crosshair.position.y > transform.position.y) {
			weaponSprite.sortingOrder = 0;
		}
		if (crosshair.position.y < transform.position.y) {
			weaponSprite.sortingOrder = 2;
		}
	}
}
