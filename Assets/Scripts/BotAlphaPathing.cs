/**
    BotAlphaPathing.cs: Makes the Enemy path between two points (its origin and another placeable point), also if the child aggro collider detects a player, it'll make the enemy's target the player instead.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BotAlphaPathing : MonoBehaviour {

    public float pause_time;
    public GameObject point; // TODO: Replace this w/ a Child Point later
    private float timer;
    private NavMeshAgent nav_agent;
    private Vector3 nav_point;
    private Vector3 origin_point;
    private bool flip = true;
    private GameObject Player;
    private bool is_aggrod = false;
    public float aggro_speed = 2.0f;

    // Use this for initialization
    void Start() {
        timer = pause_time;
        nav_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav_point = point.transform.position;
        origin_point = this.transform.position;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        if (is_aggrod == false) {
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
        } else {
            GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
            GetComponent<NavMeshAgent>().speed = aggro_speed;
        }
    }

    public void setAggro () {
        is_aggrod = true;
    }

    public void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene("Battle");
    }
}
