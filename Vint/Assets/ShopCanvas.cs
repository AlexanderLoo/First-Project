using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopCanvas : MonoBehaviour {

	public Scrollbar _scrollBar;
	public float valueController, smoothing;
	private float finalValue;

	//Si se presiona el botón derecho scrolleamos un valor definido hacia la derecha
	public void RightButtonPressed(){

		finalValue = _scrollBar.value + valueController;
	}

	//Del mismo modo hacia la izquierda
	public void LeftButtonPressed(){

		finalValue = _scrollBar.value - valueController;
	}

	public void BackHomeScreen(){

		SceneManager.LoadScene ("HomeScreen");
	}

	void Update(){

		_scrollBar.value = Mathf.Lerp (_scrollBar.value, finalValue, Time.deltaTime * smoothing);

	}

	//*********TESTING************

	public void AsteroidsVersion(){

		PlayerPrefs.SetInt ("CurrentArtStyle", 0);
	}

	public void CatVersion(){

		PlayerPrefs.SetInt ("CurrentArtStyle", 1);
	}
}
