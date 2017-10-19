using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArtStyles : ScriptableObject {

	public string artStyleName;
	public int cost;
	public GameObject player;
	public GameObject[] enemies;
	public GameObject bullet;
}
