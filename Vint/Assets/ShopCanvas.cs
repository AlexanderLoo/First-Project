using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopCanvas : MonoBehaviour {


	public Scrollbar _scrollBar;
	public float valueController;

	//Si se presiona el botón derecho scrolleamos un valor definido hacia la derecha
	public void RightButtonPressed(){
		
		_scrollBar.value += valueController;
	}

	//Del mismo modo hacia la izquierda
	public void LeftButtonPressed(){

		_scrollBar.value -= valueController;
	}

	public void BackHomeScreen(){

		SceneManager.LoadScene ("HomeScreen");
	}
}
