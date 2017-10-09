using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCoins : MonoBehaviour {

	private Text totalCoinstext;

	void Awake(){

		totalCoinstext = GetComponent<Text> ();
	}

	void Start(){

		totalCoinstext.text = DataManager.dataManager.totalCoins.ToString ();
	}
}
