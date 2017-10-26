using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackgroundSize : MonoBehaviour {

	void Start(){

		Sprite spriteSize = gameObject.GetComponent<SpriteRenderer> ().sprite;

		float pu = spriteSize.pixelsPerUnit;

		//Transformamos las medidas en metros del tamaño mínimo y máximo en las coordenadas X y Y
		Vector3 upperRightCorner = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 1));
		Vector3 lowerLeftCorner = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		Vector3 screenMeters = upperRightCorner - lowerLeftCorner;

		float screenWithMeters = screenMeters.x;

		float unityPixelPerMeter = (Screen.width / screenWithMeters);

		float proportionUnityToSprite = pu / unityPixelPerMeter;

		float originalX = spriteSize.rect.size.x;
		float originalY = spriteSize.rect.size.y;

		float scaleX = Screen.width / originalX;
		float scaleY = Screen.height / originalY;

		float generalProportion = 1f;

		if (scaleX > scaleY) {
			generalProportion = scaleX;
		} else {
			generalProportion = scaleY;
		}
		transform.localScale = Vector3.one * (generalProportion * proportionUnityToSprite);
	}
}
