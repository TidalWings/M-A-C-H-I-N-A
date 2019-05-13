using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWin : MonoBehaviour {

	public void onWin() {
        	GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>().loadPrev();
	}
}
