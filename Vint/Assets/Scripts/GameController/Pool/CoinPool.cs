using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour {

	public GameObject coin;
	private GameObject[] coinList;

	void Start(){

		coinList = new GameObject[10];
		for (int i = 0; i < coinList.Length; i++) {

			GameObject newCoin = (GameObject)Instantiate (coin);
			newCoin.SetActive (false);
			coinList [i] = newCoin;
		}
	}

	public GameObject SpawnCoins(Vector2 pos){

		for (int i = 0; i < coinList.Length; i++) {
			if (coinList[i].activeSelf == false) {

				coinList [i].SetActive (true);
				coinList [i].transform.position = pos;
				coinList [i].transform.rotation = Quaternion.identity;
				return coinList [i];
			}
		}
		return null;
	}
}
