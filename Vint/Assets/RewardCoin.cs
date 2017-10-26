using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardCoin : MonoBehaviour {

	private Image image;
	private Color finalColor = Color.clear;
	public float vanishTime;

	void Awake(){

		image = GetComponent<Image> ();
	}

	void Update(){
		
		if (image.color == Color.clear) {
			gameObject.SetActive (false);
		} else {
			//Desaparecemos la imagen
			finalColor = Color.Lerp (Color.white, Color.clear, vanishTime * Time.deltaTime);
			image.color = finalColor;
		}
	}

}
