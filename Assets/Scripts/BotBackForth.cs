using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotBackForth : MonoBehaviour {

	public float pause_time;
	public GameObject point; // TODO: Replace this w/ a Child Point later
    private float timer;
	private NavMeshAgent nav_agent;
	private Vector3 nav_point;
	private Vector3 origin_point;
	private bool flip = true;

	// Use this for initialization
	void Start () {
		timer = pause_time;
		nav_agent = GetComponent<NavMeshAgent>();
		nav_point = point.transform.position;
		origin_point = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= pause_time) {
			// TODO: One-line this "If"
            if (flip) {
                nav_agent.SetDestination(nav_point);
            } else {
                nav_agent.SetDestination(origin_point);
            }
			flip = !flip;
			timer = 0;
		}
	}
}
