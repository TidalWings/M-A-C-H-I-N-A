using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * https://www.youtube.com/watch?v=2PJ99qDsZq4
 */

public class GameManagerScript : MonoBehaviour {
	private string current_scene;
	private string previous_scene;
	private HashSet<string> deleted_items = new HashSet<string>();
	private Vector3 battle_spawn;

	public float skybox_speed = 0.25f;
	// CHECKING CLASS INSTANCES IS PART OF THE SINGLETON PATTERN
	private static GameManagerScript _instance = null;
	public static GameManagerScript Instance {
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
		// This runs on a NEW SCENE, DO whatever in this IF you need to
		if (current_scene != SceneManager.GetActiveScene().name) {

			previous_scene = current_scene;
			current_scene = SceneManager.GetActiveScene().name;

			GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

			foreach (var _ in items) {
				if (deleted_items.Contains(_.name)) {
					Destroy(_);
				}
			}
			
			foreach (var _ in enemies) {
				if (deleted_items.Contains(_.name)) {
					Destroy(_);
				}
			}

			if (previous_scene == "Battle") {
				GameObject Player = GameObject.FindGameObjectWithTag("Player");
				Player.transform.position = battle_spawn;
			} else {
				GameObject[] spawn_point = GameObject.FindGameObjectsWithTag("Spawn Point");
				GameObject Player = GameObject.FindGameObjectWithTag("Player");

				foreach (var item in spawn_point) {
					if (item.name == previous_scene) {
						Player.transform.position = item.transform.position;
					}
				}
			}
		}
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skybox_speed); // Rotates the Skybox
    }

	public void loadPrev() {
		SceneManager.LoadScene(previous_scene);
	}

	public void addOntoDelete(string to_delete) {
		deleted_items.Add(to_delete);
	}

	public void addPosition(Vector3 to_add) {
		battle_spawn = to_add;
	}
}
