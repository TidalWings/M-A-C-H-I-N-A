using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		

	}

	public void OnTriggerEnter(Collider other) {
		// Debug.Log("HIT");

		if (other.gameObject.name == "Player") {
			Destroy (gameObject);
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
}
