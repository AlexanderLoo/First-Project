	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSpawnsPosition : MonoBehaviour {

	public GameObject topSpawn, bottomSpawn, rightSpawn, leftSpawn;


	void Start(){
		//Ajustamos los spawns según el tamaño de la pantalla
		topSpawn.transform.position = new Vector2 (0, GetScreenSize.screenSize.maxInY - 1.5f);
		bottomSpawn.transform.position = new Vector2 (0, -GetScreenSize.screenSize.maxInY + 1.5f);
		rightSpawn.transform.position = new Vector2 (GetScreenSize.screenSize.maxInX - 1.5f, 0);
		leftSpawn.transform.position = new Vector2 (-GetScreenSize.screenSize.maxInX + 1.5f, 0);
	}
}
