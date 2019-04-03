using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour {

	public void quit() {
		Debug.Log ("quit");
		Application.Quit();
	}
}
