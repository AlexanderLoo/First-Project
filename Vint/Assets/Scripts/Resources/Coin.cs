using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public float destroyTime;
	private SpriteRenderer _spriteRenderer;
	private float targetAlpha;
	private bool StartBlinking = false;

	void OnEnable(){
		//Hacemos desaparecer la moneda después de un breve periodo de tiempo
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		Invoke ("Blink", 2);
		Invoke ("DestroyCoin",destroyTime);

	}
	void Update(){
		ManageBlinking ();
	}

	void OnTriggerEnter2D(Collider2D other){
		//Si el Player Colisiona con moneda, esta se desactiva y agregamos una moneda al total de monedas del player
		if (other.CompareTag("Player")) {
			DataManager.dataManager.CoinsManager (1);
			gameObject.SetActive (false);
		}
	}

	//Función para desactivar la moneda (QUEDA PENDIENTE DARLE EL EFECTO DE PARPADEO ANTES DE DESAPARECER)
	void DestroyCoin(){

		gameObject.SetActive (false);
		StartBlinking = false;


	}
	void Blink(){
		StartBlinking = true;	
	}

	void OnDisable(){
		CancelInvoke ("DestroyCoin");
		CancelInvoke ("Blink");

		
	}

	void ManageBlinking (){
		if (StartBlinking) {
			Color newColor = _spriteRenderer.color;
			newColor.a = Mathf.Lerp (newColor.a, targetAlpha, Time.deltaTime * 20);
			if (newColor.a < 0.05f) {
				targetAlpha = 1;
			}
			if (newColor.a > 0.95f) {
				targetAlpha = 0;
			}
			_spriteRenderer.color = newColor;
	
		} else {
			Color newColor = _spriteRenderer.color;
			newColor.a = 1; 
			_spriteRenderer.color = newColor;
		}
	}
}
