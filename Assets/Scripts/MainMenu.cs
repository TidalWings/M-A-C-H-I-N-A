using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://www.youtube.com/watch?v=zc8ac_qUXQY

public class MainMenu : MonoBehaviour {
	// TODO: Make Main Menu work
	public void PlayButton() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}	

	public void EndGame() {
		Debug.Log ("QUIT!");
		Application.Quit();
	}
}
