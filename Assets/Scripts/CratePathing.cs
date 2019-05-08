/**
 * CratePathing.cs: 
 *
 * Reference: https://answers.unity.com/questions/570573/how-do-i-slowly-translate-a-object-to-a-other-obje.html
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CratePathing : MonoBehaviour {

    // public float pause_time;
	public float speed;
    public GameObject point; // TODO: Replace this w/ a Child Point later
    private Vector3 nav_point;
    private Vector3 origin_point;
    private bool flip = true;

    // Use this for initialization
    void Start() {
        // timer = pause_time;
        nav_point = point.transform.position;
        origin_point = this.transform.position;
    }

    // Update is called once per frame
    void Update() {
		float step = Time.deltaTime * speed;

		if (transform.position == nav_point) {
			flip = true;
		} else if (transform.position == origin_point) {
			flip = false;
		}

		if (flip) {
			transform.position = Vector3.MoveTowards(transform.position, origin_point, step);
		} else {
			transform.position = Vector3.MoveTowards(transform.position, nav_point, step);
		}
    }
}
