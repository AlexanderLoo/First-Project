using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour {


	public GameObject optionPanel, sharePanel;
	public AudioSource music;
	private bool optionButtonPressed, shareButtonPressed;

	public void OptionButtonManager(){

		optionPanel.SetActive (!optionButtonPressed);
		optionButtonPressed = !optionButtonPressed;
	}

	public void ShareButtonManager(){

		sharePanel.SetActive (!shareButtonPressed);
		shareButtonPressed = !shareButtonPressed;
	}

	public void MuteMusic(){

		music.mute = !music.mute;
	}

}
