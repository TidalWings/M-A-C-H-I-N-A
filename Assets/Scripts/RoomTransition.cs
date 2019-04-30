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
		if (current_scene != SceneManager.GetActiveScene().name) {
			// This runs on a NEW SCENE, DO whatever in this IF you need to
			previous_scene = current_scene;
			current_scene = SceneManager.GetActiveScene().name;

            GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
			foreach(var item in doors) {
				if (previous_scene == item.GetComponent<DoorTransition>().scene_name) {
					// Grab the Coordinates of the Spawn Point on Each Door
					item.;
					// Set the Player to that corresponding spawn point
				}			
			}

			Debug.Log("This was previous scene: " + previous_scene);
			// Debug.Log("This was current scene: " + current_scene);
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
