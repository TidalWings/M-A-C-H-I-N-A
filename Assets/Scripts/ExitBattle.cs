using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitBattle : MonoBehaviour {
	public string scene_name;
	void Start() {
		scene_name = PlayerPrefs.GetString("lastLoadedScene");
	}
		
	public void OnMouseDown() {
		Debug.Log(scene_name);
		//PlayerPrefs.SetString ("lastLoadedScene", SceneManager.GetActiveScene ().name);
		//Debug.Log(scene_name);
		SceneManager.LoadScene (scene_name);
	}

}
