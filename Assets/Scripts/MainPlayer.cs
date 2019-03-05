using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainPlayer : MonoBehaviour {
	
	void Update () {
		// On RMB Click, Check if the point is a valid move, if yes then go there.
		if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit)) {
                GetComponent<NavMeshAgent>().SetDestination(rayHit.point);
            }
		}
	}
}