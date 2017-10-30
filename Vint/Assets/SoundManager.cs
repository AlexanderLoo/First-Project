using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

	public Image soundWave;
	private AudioListener _al;
	private AudioSource _as;
	private bool buttonPressed = true;

	void Awake(){
		_al = Camera.main.GetComponent<AudioListener> ();
		_as = GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt("UseSound") != 1) {
			MuteSound ();
		}
	}

	//Función para mutear o restablecer el sonido al presionar el botón
	public void MuteSound(){

		_al.enabled = !buttonPressed;
		soundWave.enabled = !buttonPressed;
		buttonPressed = !buttonPressed;
		if (buttonPressed) {
			_as.Play ();
			PlayerPrefs.SetInt ("UseSound", 1);
		} else {
			PlayerPrefs.SetInt ("UseSound", 0);
		}
	}
}
