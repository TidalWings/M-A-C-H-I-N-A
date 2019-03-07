using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour {

	// TODO: Figure out how to use a Public scene instead of ints
	public int scene_index;

	public void OnCollisionEnter(Collision other) {
		Debug.Log(other.gameObject);
		if (other.gameObject.name == "Larry" || other.gameObject.name == "Player") {
			// Debug.Log("hello");
			SceneManager.LoadScene(scene_index);
		}
	}
}
