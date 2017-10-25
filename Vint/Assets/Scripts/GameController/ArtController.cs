using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtController : MonoBehaviour {

	//Una lista de todos los diseños que existen
	public ArtStyles[] artStyles;
	public int currentArtStye;
	public SpriteRenderer background;

	private EnemyPool enemyPool;	
	private BulletsPool bulletPool;


	void Awake(){

		//Obtemos el índice del último diseño equipado
		currentArtStye = PlayerPrefs.GetInt ("CurrentArtStyle");
		//Instanciamos al player según el diseño obtenido
		Instantiate (artStyles [currentArtStye].player, Vector2.zero, Quaternion.identity);
		enemyPool = GameObject.Find ("EnemyPool").GetComponent<EnemyPool>();
		bulletPool = GameObject.Find ("BulletPool").GetComponent<BulletsPool>();

		//Por cada tipo de enemigo en el diseño obtenido se les agrega al pool de enemigos
		for (int i = 0; i < artStyles[currentArtStye].enemies.Length; i++) {

			GameObject newEnemyType = artStyles [currentArtStye].enemies [i];
			enemyPool.enemiesTypes [i] = newEnemyType;
		}
		//Agregamos la bala correspondiente
		bulletPool.bulletPrefab = artStyles[currentArtStye].bullet;

		if (artStyles [currentArtStye].background != null) {
			//Asignamos el respectivo background sólo si el artystyle tiene uno
			background.sprite = artStyles [currentArtStye].background;
		} else {
			//En caso contrario desactivamos el fondo
			background.gameObject.SetActive (false);
		}
		//Cambiamos de color al background(Por ahora el de la cámara)
		/*Color newColor = new Color(1/artStyles[currentArtStye].backgroundColor.x,
			1/artStyles[currentArtStye].backgroundColor.y,
			1/artStyles[currentArtStye].backgroundColor.z);
		Camera.main.backgroundColor = newColor;*/
	
	}
}
