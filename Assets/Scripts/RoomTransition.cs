using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * https://www.youtube.com/watch?v=2PJ99qDsZq4
 */

public class RoomTransition : MonoBehaviour {
	private string current_scene;
	private string previous_scene;
	// CHECKING CLASS INSTANCES IS PART OF THE SINGLETON PATTERN
	private static RoomTransition _instance = null;
	public static RoomTransition Instance {
		get { return _instance; }
	}

    void Awake() {
		// PART OF THE SINGLETON PATTERN
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad(this);
		} else {
			Destroy(this.gameObject);
		}
        current_scene = SceneManager.GetActiveScene().name;
        previous_scene = SceneManager.GetActiveScene().name;
    }

	void Update () {
		if (current_scene != SceneManager.GetActiveScene().name) {
			// This runs on a NEW SCENE, DO whatever in this IF you need to
			previous_scene = current_scene;
			current_scene = SceneManager.GetActiveScene().name;
			GameObject[] spawn_point = GameObject.FindGameObjectsWithTag("Spawn Point");
			GameObject Player = GameObject.FindGameObjectWithTag("Player");

			foreach (var item in spawn_point) {
				if (item.name == previous_scene) {
					Player.transform.position = item.transform.position;
				}
			}
		}
	}
}
