using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnCube : MonoBehaviour {

	[SerializeField] GameObject spawn_point;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			SceneManager.LoadScene("Box_World_02");
		}
	}
}