using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public static AudioController audioController;
	private AudioSource _audioSource;

	//Clips
	public AudioClip buttonAC, pauseButtonAC, dropCoinAC, pickCoinAC, gameOverAC;
	//Este audioclip varia según el tema equipado
	public AudioClip currentShotSoundAC;

	void Awake(){

		if (audioController == null) {
			DontDestroyOnLoad (gameObject);
			audioController = this;
		} 
		else if (audioController != this){
			Destroy (gameObject);
		}
	}

	void Start(){

		_audioSource = GetComponent<AudioSource> ();
	}


	//Las siguientes funciones permiten activar los sonidos
	void ActiveSound(AudioClip ac){

		_audioSource.Stop ();
		_audioSource.clip = ac;
		_audioSource.Play ();
	}

	//Sonido al presionar un botón
	public void PlayButtonSound(){

		ActiveSound (buttonAC);
	}

	public void PlayPauseButtonSound(){

		ActiveSound (pauseButtonAC);
	}
	//Sonido al dropear una moneda
	public void PlayDropCoinSound(){

		ActiveSound (dropCoinAC);
	}

	//Sonido al recojer moneda
	public void PlayPickCoinSound(){

		ActiveSound (pickCoinAC);
	}
	//Sonido de G	ame Over
	public void PlayGameOverSound(){

		ActiveSound (gameOverAC);
	}

	public void PlayShotSound(){

		ActiveSound (currentShotSoundAC);
	}

}
