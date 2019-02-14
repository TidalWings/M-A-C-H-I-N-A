using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speed = 0.004f;

	// Use this for initialization
	void Start () {

	}

	void Update () {
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;

		transform.Translate(deltaX, 0, deltaZ);
	}
}
