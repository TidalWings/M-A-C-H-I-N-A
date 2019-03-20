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
			// Here we create an array of all Objs that are Clones of Sweets by checking for Tags
			GameObject[] items = GameObject.FindGameObjectsWithTag("Sweets");
			// This checks to make sure that if we have only 1 Sweets Nav Sprite at a time by deleting the rest
			if (items.Length != 0) { foreach (GameObject _ in items) Destroy(_); }
			// TODO: Instantiate w/out creating an empty var (compiler complains)
			GameObject obj = Instantiate(nav_sprite, new Vector3(rayHit.point.x, (rayHit.point.y + 0.1f), rayHit.point.z), Quaternion.Euler(new Vector3(90, 0, 0))) as GameObject;
			// TODO: Properly Instantiate ABOVE item. This is another spaghetti fix so that it does "Something" to make the compiler not complain.
			Debug.Log(obj);
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
