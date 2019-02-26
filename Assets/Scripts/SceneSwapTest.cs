using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://www.youtube.com/watch?v=Oadq-IrOazg

public class SceneSwapTest : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("o")) {
            SceneManager.LoadScene(0);
        } else if (Input.GetKeyDown("p")) {
            SceneManager.LoadScene(1);
		}
	}
}
