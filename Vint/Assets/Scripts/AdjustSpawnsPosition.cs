using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSpawnsPosition : MonoBehaviour {

	public GetScreenSize screenSize;
	public GameObject topSpawn, bottomSpawn, rightSpawn, leftSpawn;

	void Start(){
		//Ajustamos los spawns según el tamaño de la pantalla
		topSpawn.transform.position = new Vector2 (0, screenSize.maxInY - 2);
		bottomSpawn.transform.position = new Vector2 (0, -screenSize.maxInY + 2);
		rightSpawn.transform.position = new Vector2 (screenSize.maxInX - 2, 0);
		leftSpawn.transform.position = new Vector2 (-screenSize.maxInX + 2, 0);
	}
}
