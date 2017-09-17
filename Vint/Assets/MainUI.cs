using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour {


	public GameObject optionPanel, sharePanel;
	private bool optionButtonPressed, shareButtonPressed;




	public void OptionButtonManager(){

		optionPanel.SetActive (!optionButtonPressed);
		optionButtonPressed = !optionButtonPressed;
	}

	public void ShareButtonManager(){

		sharePanel.SetActive (!shareButtonPressed);
		shareButtonPressed = !shareButtonPressed;
	}



}
