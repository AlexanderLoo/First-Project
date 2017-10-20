using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other){

		if (other.CompareTag("Player")) {
			//Si el player sobrepasa el límite en X(sea positivo o negativo), se invierte sólo su posición en X
			if (other.transform.position.x > GetScreenSize.screenSize.maxInX || other.transform.position.x < -GetScreenSize.screenSize.maxInX) {
				Vector2 newPos = new Vector2 (other.transform.position.x * -1, other.transform.position.y);
				other.transform.position = newPos;
			}
			//Si el player sobrepasa el límite en Y(sea positivo o negativo), se invierte sólo su posición en Y
			if (other.transform.position.y > GetScreenSize.screenSize.maxInY || other.transform.position.y < -GetScreenSize.screenSize.maxInY) {
				Vector2 newPos = new Vector2 (other.transform.position.x, other.transform.position.y * -1);
				other.transform.position = newPos;
			}
		}
	}
}
