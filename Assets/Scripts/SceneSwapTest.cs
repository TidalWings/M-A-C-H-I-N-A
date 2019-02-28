using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Need to Import this for Scene Swapping

// https://www.youtube.com/watch?v=Oadq-IrOazg

public class SceneSwapTest : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// GetKeyDown is just grabbing keyboard input
		if (Input.GetKeyDown("o")) {
			// The number in LoadScene refers to the "index" of the desired scene under the games build settings
            SceneManager.LoadScene(0);
        } else if (Input.GetKeyDown("p")) {
            SceneManager.LoadScene(1);
		}
	}
}
