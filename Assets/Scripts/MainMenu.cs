using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://www.youtube.com/watch?v=zc8ac_qUXQY

public class MainMenu : MonoBehaviour {
	// TODO: Make Main Menu work
	public void PlayButton() {
		SceneManager.LoadScene(5);
	}	

	public void EndGame() {
		Application.Quit();
	}
}
