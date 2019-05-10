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
            SceneManager.LoadScene("Tutorial_01");
        } else if (Input.GetKeyDown("2")) {
            SceneManager.LoadScene("Tutorial_02");
		} else if (Input.GetKeyDown("3")) {
			SceneManager.LoadScene("Tutorial_03");
		} else if (Input.GetKeyDown("4")) {
			SceneManager.LoadScene("Tutorial_04");
		} else if (Input.GetKeyDown("5")) {
			SceneManager.LoadScene("Box_World_01");
		} else if (Input.GetKeyDown("6")) {
			SceneManager.LoadScene("Box_World_02");
		} else if (Input.GetKeyDown("7")) {
			SceneManager.LoadScene("Box_World_03");
		} else if (Input.GetKeyDown("8")) {
			SceneManager.LoadScene("Box_World_04");
		} else if (Input.GetKeyDown("9")) {
            SceneManager.LoadScene("Boss_Room");
        } else if (Input.GetKeyDown("0")) {
			if (SceneManager.GetActiveScene().name == "Battle") {
                // Run this on a BATTLE WIN and you'll return to the Scene w/ the enemies defeated
                GameObject.FindGameObjectWithTag("GameController").GetComponent<RoomTransition>().loadPrev();
            }
		}
	}
}
