using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ClickMove : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// If our click is a valid point on the Navmesh then, set that point as our destination
		if (Input.GetButtonDown("Fire1")) {
			// Gets a Ray from clicking
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHit;
			if (Physics.Raycast(ray, out rayHit)) {
				// This takes the Point from the rayHit and sets it as our NavMesh Agent
				// https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html
				GetComponent<NavMeshAgent>().SetDestination(rayHit.point);
			}
		}
	}
}
