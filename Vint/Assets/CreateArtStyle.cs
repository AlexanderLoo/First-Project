using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

//Esta clase sirve para crear assets desde el editor
//Creamos assets de tipo "ArtStyles" 
public class CreateArtStyle {

	[MenuItem("Assets/Create/Art Style")]
	public static void Create(){

		ArtStyles asset = ScriptableObject.CreateInstance<ArtStyles> ();
		AssetDatabase.CreateAsset (asset, "Assets/ArtStyles/NewArtStyle.asset");
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;
	}
}
#endif
