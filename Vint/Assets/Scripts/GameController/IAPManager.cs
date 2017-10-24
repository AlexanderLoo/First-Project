using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour {

	public GameObject iapScreen;


	//Activamos la pantalla de compra 
	public void ActiveIAPScreen(){

		iapScreen.SetActive (true);
	}
	//Desactivamos la pantalla de compra
	public void DeactivateIAPScreen(){

		iapScreen.SetActive (false);
	}
}
