using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour {

	public string scene_name;
	// private ScreenWipe screenWipe;

	// void Awake() {
	// 	screenWipe = FindObjectOfType<ScreenWipe>();
	// }

	public void OnTriggerEnter(Collider other) {
		//yield return new WaitForSeconds (1f);
		StartCoroutine(SmoothTransition());
		// // Debug.Log (other.gameObject.name);
		SceneManager.LoadScene(scene_name);
	}

	IEnumerator SmoothTransition() {
		yield return new WaitForSeconds(1f);

		// screenWipe.ToggleWipe(true);
		// while (!screenWipe.isDone) {
		// 	yield return null;
		// }

		// AsyncOperation operation = SceneManager.LoadSceneAsync(scene_name);
		// while(!operation.isDone) {
		// 	yield return null;
		// }

		// screenWipe.ToggleWipe(false);
	}
}
