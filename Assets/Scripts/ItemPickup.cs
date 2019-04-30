using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {
	bool pickup = false;
	[SerializeField] GameObject pickupWindow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		

	}

	public void OnTriggerEnter(Collider other) {
		// Debug.Log("HIT");

		if (other.gameObject.name == "Player") {
			//pickup code goes before destroy
			pickup = true;
			this.Open ();
			gameObject.SetActive (false);
			//pickupWindow.SetActive (true);
			//Destroy (gameObject);
			Debug.Log ("pickup");
		}

		// TODO: Add Left Click feature cause current implentation is for convenience
        // if (Input.GetMouseButtonDown(0) && other.gameObject.name == "Player") {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;

        //     if (Physics.Raycast(ray, out hit)) {
        //         if (hit.transform.name == "Item") {
        //         	Debug.Log("ITEM!");
        //         } else {
        //         	Debug.Log("NOT Item!");
        //         }
        //     }
        // }
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
