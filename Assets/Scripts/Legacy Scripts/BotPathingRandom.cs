using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// This was taken from a site for example purposes:
//      https://forum.unity.com/threads/solved-random-wander-ai-using-navmesh.327950/

public class BotPathingRandom : MonoBehaviour {

	// Initializing variables
    public float radius;
    public float time;
    // Nav Mesh Agent is the component that we attach to players/enemies to allow them to path on the Nav Mesh
    private NavMeshAgent nav_agent;
    private float timer;

	// Use this for initialization
    void OnEnable() {
        nav_agent = GetComponent<NavMeshAgent>();
        timer = time;
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
		// Simple constant timer using setDestination on NavMesh
        if (timer >= time) {
            Vector3 newPos = RandomNavSphere(transform.position, radius, -1);
            nav_agent.SetDestination(newPos);
            timer = 0;
        }
    }

	// This function uses a Unit Sphere to grab a random point on the NavMesh inside of a what radius you defined for the sphere
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
}
