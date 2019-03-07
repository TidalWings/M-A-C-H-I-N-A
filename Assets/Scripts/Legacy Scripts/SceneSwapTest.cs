using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Need to Import this for Scene Swapping

// https://www.youtube.com/watch?v=Oadq-IrOazg

public class SceneSwapTest : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// GetKeyDown is just grabbing keyboard input
		if (Input.GetKeyDown("1")) {
			// The number in LoadScene refers to the "index" of the desired scene under the games build settings
            SceneManager.LoadScene(0);
        } else if (Input.GetKeyDown("2")) {
            SceneManager.LoadScene(1);
		} else if (Input.GetKeyDown("3")) {
			SceneManager.LoadScene(2);
		} else if (Input.GetKeyDown("4")) {
			SceneManager.LoadScene(3);
		}
	}
}
