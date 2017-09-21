using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour {

	public Text bestScoreText;

	void OnEnable(){
		
		bestScoreText.text = PlayerPrefs.GetInt ("BestScore").ToString ();
	}
}
