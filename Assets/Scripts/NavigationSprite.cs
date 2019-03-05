using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationSprite : MonoBehaviour {

    public GameObject nav_sprite;
	
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
		// TODO: Sample the Nav Mesh to make sure it's a legal point
        if (Physics.Raycast(ray, out rayHit) && Input.GetMouseButtonDown(1)) {
			GameObject[] items = GameObject.FindGameObjectsWithTag("Sweets");
			if (items.Length != 0) { foreach (GameObject _ in items) Destroy(_); }
			// TODO: Instantiate w/out creating an empty var (compiler complains)
			GameObject obj = Instantiate(nav_sprite, new Vector3(rayHit.point.x, (rayHit.point.y + 0.1f), rayHit.point.z), Quaternion.Euler(new Vector3(90, 0, 0))) as GameObject;
        }
	}

    public void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Sweets(Clone)") {
			Destroy(other.gameObject);
		}
    }
}
