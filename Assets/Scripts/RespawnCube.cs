using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnCube : MonoBehaviour {

	[SerializeField] string World_Respawn_Name;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			SceneManager.LoadScene(World_Respawn_Name);
		}
	}
}