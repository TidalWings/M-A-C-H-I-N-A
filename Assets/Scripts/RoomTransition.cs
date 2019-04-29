using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransition : MonoBehaviour {
	private string current_scene;
	private string previous_scene;
	public GameObject Player;

	void Start () {
        current_scene = SceneManager.GetActiveScene().name;
        previous_scene = SceneManager.GetActiveScene().name;
	}

	void Update () {
		// This runs on a NEW SCENE, DO whatever in this IF you need to
		if (current_scene != SceneManager.GetActiveScene().name) {
			previous_scene = current_scene;
			current_scene = SceneManager.GetActiveScene().name;
			
			
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
