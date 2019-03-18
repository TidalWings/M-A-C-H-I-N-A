using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour {

	// TODO: Figure out how to use a Public scene instead of ints
	public string scene_name;



	//public void OnCollisionEnter(Collision other) {
		//Debug.Log(other.gameObject);
		//if (other.gameObject.name == "Larry" || other.gameObject.name == "Player") {
	//	Debug.Log("hello");
	//	SceneManager.LoadScene(scene_name);
		//}
	//}

	public void OnTriggerEnter(Collider other) {
		//yield return new WaitForSeconds (1f);
		StartCoroutine(SmoothTransition());
		Debug.Log (other.gameObject.name);
		SceneManager.LoadScene (scene_name);
	}

	IEnumerator SmoothTransition() {
		yield return new WaitForSeconds (1f);
	}
}
