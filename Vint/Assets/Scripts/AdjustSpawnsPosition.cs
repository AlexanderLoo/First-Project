﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSpawnsPosition : MonoBehaviour {

	public GameObject topSpawn, buttonSpawn, rightSpawn, leftSpawn;
	public float minInX, maxInX, minInY, maxInY;
	public GameObject left,righ,down, up;

	void Awake(){

		//Accedemos al tamaño del alto y el ancho de la pantalla(cualquier resolución) y lo guardamos en un Vector2
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		Vector2 screenPos = new Vector2 (screenWidth, screenHeight);
		//Convertimos el tamaño de la pantalla(pixels) en el tamaño en medidas del mundo
		Vector2 newPos = Camera.main.ScreenToWorldPoint (screenPos);

		//Alineamos los objetos vacíos fuera de la pantalla por 2 unidades
		topSpawn.transform.position = new Vector2 (0, newPos.y - 2);
		buttonSpawn.transform.position = new Vector2 (0, -newPos.y + 2);
		rightSpawn.transform.position = new Vector2 (newPos.x - 2, 0);
		leftSpawn.transform.position = new Vector2 (-newPos.x + 2, 0);

		Vector2 NewScale = new Vector2 (-newPos.x -1	, 0);
		left.transform.position = NewScale; 
		righ.transform.position = new Vector2 (newPos.x + 1, 0);
		up.transform.position = new Vector2 (0, newPos.y + 1);
		down.transform.position;

		Vector2 localScale = new Vector2 (transform.localScale.x, newPos.y+newPos.y);
		left.transform.localScale = localScale; 

		//Obtenemos los límites en los ejes 	X y Y
		minInX = -newPos.x;
		maxInX = newPos.x;
		minInY = -newPos.y;
		maxInY = newPos.y;
	}
}
