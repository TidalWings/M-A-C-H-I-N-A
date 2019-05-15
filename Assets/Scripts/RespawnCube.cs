using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnCube : MonoBehaviour {

	[SerializeField] string World_Respawn_Name;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>().player_health_current -= 2;
			SceneManager.LoadScene(World_Respawn_Name);
		}
	}
}