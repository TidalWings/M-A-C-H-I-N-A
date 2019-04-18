using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainPlayer : MonoBehaviour {
	
    public GameObject nav_sprite;
	void Update () {
		// On RMB Click, Check if the point is a valid move, if yes then go there.
		if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit)) {
                // This checks to make sure that we can ONLY click on the pathable ground
                if (rayHit.transform.tag == "Ground") {
                    GetComponent<NavMeshAgent>().SetDestination(rayHit.point);
                    // Here we create an array of all Objs that are Clones of Sweets by checking for Tags
                    GameObject[] items = GameObject.FindGameObjectsWithTag("Sweets");
                    // This checks to make sure that if we have only 1 Sweets Nav Sprite at a time by deleting the rest
                    if (items.Length != 0) { foreach (GameObject _ in items) Destroy(_); }
                    Instantiate(nav_sprite, new Vector3(rayHit.point.x, (rayHit.point.y + 0.1f), rayHit.point.z), Quaternion.Euler(new Vector3(90, 0, 0)));
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
}