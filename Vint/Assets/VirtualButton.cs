using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	public bool buttonPressed = false;

	public virtual void OnPointerDown(PointerEventData ped){

		buttonPressed = true;
	}

	public virtual void OnPointerUp(PointerEventData ped){

		buttonPressed = false;
	}
}
