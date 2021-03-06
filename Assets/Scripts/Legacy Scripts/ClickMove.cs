﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// From variety of YouTube "Click to Move" NavMesh tutorials
// Here are a select few:
// 		https://www.youtube.com/watch?v=GANwdCKoimU
// 		https://docs.unity3d.com/Manual/nav-MoveToClickPoint.html
//		https://www.youtube.com/watch?v=CHV1ymlw-P8
// 		https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html

public class ClickMove : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// If our click is a valid point on the Navmesh then, set that point as our destination
		if (Input.GetMouseButtonDown(1)) {
			// Gets a Ray from clicking
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHit;
			if (Physics.Raycast(ray, out rayHit)) {
				// This takes the Point from the rayHit and sets it as our NavMesh Agent
				GetComponent<NavMeshAgent>().SetDestination(rayHit.point);
			}
		}
	}

	// This is for QuickReview to have a component to latch onto for example purposes
	// TODO: Figure out why there's a ambiguous function error
	public void painedScreaming() {
		Debug.Log("Ow.");
	}
}
