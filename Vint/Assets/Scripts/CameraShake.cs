using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour{
	
	public float shakeAmount = 0.7f;

	void Update(){
		//Hacemos temblar la cámara
		//Este código cambia ligeramente la posición de la camara(QUEDA PENDIENTE ARREGLARLO)
		transform.position += Random.insideUnitSphere * shakeAmount;
	}
}