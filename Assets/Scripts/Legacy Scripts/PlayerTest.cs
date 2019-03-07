using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour {

	public void OnCollisionEnter(Collision other) {
		// Debug.Log(other.gameObject);
		if (other.gameObject.name == "Door") {
			Debug.Log("SUPER HIT");
		}
	} 
}
