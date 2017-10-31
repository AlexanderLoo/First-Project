using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatingWithCoins : MonoBehaviour {

	public void AddCoinsWithCheat(){

		DataManager.dataManager.CoinsManager (1000);
	}
}
