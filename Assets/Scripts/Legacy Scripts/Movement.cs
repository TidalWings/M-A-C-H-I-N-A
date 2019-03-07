using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From Textbook Example

public class Movement : MonoBehaviour {
	public float speed = 1.0f;

	void Update () {
		float deltaX = Input.GetAxis("Horizontal") * speed;  
		float deltaZ = Input.GetAxis("Vertical") * speed; 
		transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
	}
}
