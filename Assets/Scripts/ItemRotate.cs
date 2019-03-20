using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour {

	private GameObject our_item;

	// Use this for initialization
	void Start () {
		our_item = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		our_item.transform.Rotate(0, 1, 0);
	}
}
