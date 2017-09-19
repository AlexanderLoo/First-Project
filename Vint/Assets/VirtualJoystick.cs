using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Agregamos la libreria de EventSystems
using UnityEngine.EventSystems;

//Usamos IDragHandler, IPointerUpHandler, IPointerDownHandler para eventos de móviles
public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image backgroudJoystickImage;
	private Image joystickImage;	
	public Vector2 inputVector;

	void Awake(){

		backgroudJoystickImage = GetComponent<Image> ();
		//Buscamos en los hijos en el índice 0 el componente image
		joystickImage = transform.GetChild (0).GetComponent<Image> ();
	}

	public virtual void OnDrag(PointerEventData ped){

		Vector2 pos;
		//Si se esta recibiendo inputs dentro del recTransform del MovementBackgroundJoystick
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroudJoystickImage.rectTransform,ped.position,ped.pressEventCamera,out pos)) {

			//Convertimos el tamaño de las coordenadas X y Y en tamaño entre 0 a 1, haciendo una división entre la posición actual entre el tamaño total
			pos.x = (pos.x / backgroudJoystickImage.rectTransform.sizeDelta.x);
			pos.y = (pos.y / backgroudJoystickImage.rectTransform.sizeDelta.y);

			//Ajustamos el vector para asegurarnos que sus límites sean entre -1 a 1
			inputVector = new Vector2 (pos.x * 2, pos.y * 2);
			//Si la magnitud del vector es mayor que 1, entonces la normalizamos
			inputVector = (inputVector.magnitude > 1) ? inputVector.normalized : inputVector;

			//Movemos la imagen del joystick(dividimos la coordenada de backgroundJoystick entre un número para que el joystick no se salga del background)
			joystickImage.rectTransform.anchoredPosition = new Vector2(inputVector.x * (backgroudJoystickImage.rectTransform.sizeDelta.x/3),
				inputVector.y *(backgroudJoystickImage.rectTransform.sizeDelta.y/3));
		}
	}

	public virtual void OnPointerDown(PointerEventData ped){

		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped){

		//Al dejar de tocar el BackgroundJoystick, establecemos las coordenadas de ambas imagenes a cero
		inputVector = Vector2.zero;
		joystickImage.rectTransform.anchoredPosition = Vector2.zero;
	}
}
