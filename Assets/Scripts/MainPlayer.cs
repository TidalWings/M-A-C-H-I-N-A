using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainPlayer : MonoBehaviour {
	
    public GameObject nav_sprite;

	void Update () {
        
        if (Application.isMobilePlatform) {
            if (Input.touchCount == 1) {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
                    // TODO: Yes I literally reused the code that I could've probably written IFs for... but whatever y'know...
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit rayHit;
                    if (Physics.Raycast(ray, out rayHit)) {
                        // This checks to make sure that we can ONLY click on the pathable ground
                        if (rayHit.transform.tag == "Ground" || rayHit.transform.tag == "Door") {
                            GetComponent<NavMeshAgent>().SetDestination(rayHit.point);
                            // Here we create an array of all Objs that are Clones of Sweets by checking for Tags
                            GameObject[] items = GameObject.FindGameObjectsWithTag("Sweets");
                            // This checks to make sure that if we have only 1 Sweets Nav Sprite at a time by deleting the rest
                            if (items.Length != 0) { foreach (GameObject _ in items) Destroy(_); }
                            Instantiate(nav_sprite, new Vector3(rayHit.point.x, (rayHit.point.y + 0.1f), rayHit.point.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                        } else {
                            NavMeshHit smash;
                            if (NavMesh.SamplePosition(rayHit.point, out smash, 5.0f, NavMesh.AllAreas)) {
                                GetComponent<NavMeshAgent>().SetDestination(rayHit.point);
                                GameObject[] __ = GameObject.FindGameObjectsWithTag("Sweets");
                                if (__.Length != 0) { foreach (GameObject _ in __) Destroy(_); }
                                Instantiate(nav_sprite, new Vector3(smash.position.x, (smash.position.y + 0.1f), smash.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                            }
                        }
                    }
                }
            }
        } else {
            // On RMB Click, Check if the point is a valid move, if yes then go there.
            if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) || Input.GetMouseButton(1)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit rayHit;
                if (Physics.Raycast(ray, out rayHit)) {
                    // This checks to make sure that we can ONLY click on the pathable ground
                    if (rayHit.transform.tag == "Ground" || rayHit.transform.tag == "Door") {
                        GetComponent<NavMeshAgent>().SetDestination(rayHit.point);
                        // Debug.Log("This is on Mouse Hit: " + rayHit.point);
                        // Here we create an array of all Objs that are Clones of Sweets by checking for Tags
                        GameObject[] items = GameObject.FindGameObjectsWithTag("Sweets");
                        // This checks to make sure that if we have only 1 Sweets Nav Sprite at a time by deleting the rest
                        if (items.Length != 0) { foreach (GameObject _ in items) Destroy(_); }
                        Instantiate(nav_sprite, new Vector3(rayHit.point.x, (rayHit.point.y + 0.1f), rayHit.point.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    } else {
                        NavMeshHit smash;
                        if (NavMesh.SamplePosition(rayHit.point, out smash, 5.0f, NavMesh.AllAreas)) {
                            GetComponent<NavMeshAgent>().SetDestination(rayHit.point);
                            // Debug.Log("This is a point: " + smash.position);
                            GameObject[] __ = GameObject.FindGameObjectsWithTag("Sweets");
                            if (__.Length != 0) { foreach (GameObject _ in __) Destroy(_); }
                            Instantiate(nav_sprite, new Vector3(smash.position.x, (smash.position.y + 0.1f), smash.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                        }
                    }
                }
            }
        }
	}

    // OnTriggerEnter checks for collision and we can grab the Other Obj or This
    public void OnTriggerEnter(Collider other) {
        // GameObjects have Names, so we can check what the other Obj is by checking either its name or its tag
        if (other.gameObject.name == "Sweets(Clone)") {
            Destroy(other.gameObject);
        }
    }

    public void disableNavMesh() {
        gameObject.GetComponent<NavMeshAgent>().updatePosition = false;
    }

    public void enableNavMesh() {
        gameObject.GetComponent<NavMeshAgent>().updatePosition = true;
    }
}