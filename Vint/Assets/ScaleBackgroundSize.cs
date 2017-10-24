using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackgroundSize : MonoBehaviour {

	void Start(){

		Sprite spriteSize = gameObject.GetComponent<SpriteRenderer> ().sprite;
		spriteSize.rect.size.Set (Screen.width *2, Screen.height*2);
		print (spriteSize);
	}
}
