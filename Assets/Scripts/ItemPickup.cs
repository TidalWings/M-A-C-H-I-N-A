using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {
	bool pickup = false;
	[SerializeField] GameObject pickupWindow;

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			//pickup code goes before destroy
			pickup = true;
			this.Open ();
			gameObject.SetActive (false);
			//pickupWindow.SetActive (true);
			//Destroy (gameObject);
			// Debug.Log ("pickup");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>().addOntoDelete(this.name);
		}
	}
	public void OptionOne() {
		//put inventory code here
		pickupWindow.SetActive (false);
		Debug.Log ("item1");
		Destroy (gameObject);
	}

	public void OptionTwo() {
		//put inventory code here
		pickupWindow.SetActive (false);
		Debug.Log ("item2");
		Destroy (gameObject);
	}

	public void Open() {
		Debug.Log (pickup);
		if (pickup == true) {
			pickupWindow.SetActive (pickup);
		}
	}
}
