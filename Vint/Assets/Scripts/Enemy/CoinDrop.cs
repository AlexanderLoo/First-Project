using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour {

	public int randomness;
	//Si coinDrop es verdadero, se dropea una moneda cuando el enemigo es disparado(Ver "EnemyGetShot")
	public bool coinDrop;

	//Pequeña lógica para dropear monedas en base a una probabilidad(EN ESPERA DE SUGERENCIAS PARA MEJORAR EL CÓDIGO)
	void OnEnable(){

		int i = Random.Range (0, randomness);
		if (i == 0) {
			coinDrop = true;
		} 
	}	
}
