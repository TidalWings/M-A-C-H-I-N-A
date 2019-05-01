using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWorldPushOff : MonoBehaviour {

	private void OnCollisionEnter(Collision other) {
		// Debug.Log(other.gameObject.name);	
		if (other.gameObject.name == "Player") {
			other.gameObject.GetComponent<MainPlayer>().disableNavMesh();
		}
	}
}
