using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustGameLimits : MonoBehaviour {

	void Start(){
		//Escalamos el gameObject al tamaño de la pantalla
		Vector2 newScale = new Vector2 (GetScreenSize.screenSize.maxInX, GetScreenSize.screenSize.maxInY);
		transform.localScale = newScale * 2;
	}
}