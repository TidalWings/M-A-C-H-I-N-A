using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoxWorldPushOff : MonoBehaviour {
	private GameObject ActualPlayer;
	private GameObject TheEnemy;

	private void OnCollisionEnter(Collision other) {
		Debug.Log(other.gameObject.tag);
		if (other.gameObject.name == "Player") {
			ActualPlayer = other.gameObject;
			ActualPlayer.GetComponent<MainPlayer>().disableNavMesh();
			StartCoroutine(SmoothTransition());
		} 
		// TODO:
		// else if (other.gameObject.tag == "Enemy") {
		// 	TheEnemy = other.gameObject;
		// 	TheEnemy.GetComponent<NavMeshAgent>().updatePosition = false;
		// 	// TheEnemy.GetComponent<BotAlphaPathing>().disableNavMesh();
		// 	StartCoroutine(OtherSmoothTransition());
		// }
	}

    IEnumerator SmoothTransition() {
		// TODO: If the Player isn't falling re-enable NavMesh
        yield return new WaitForSeconds(1.5f);
		if (!(ActualPlayer.transform.position.y <= 4.5)) {
			ActualPlayer.GetComponent<MainPlayer>().enableNavMesh();
		}
	}
    // IEnumerator OtherSmoothTransition() {
    //     yield return new WaitForSeconds(3f);
	// 	if (!(TheEnemy.transform.position.y <= 4.5)) {
	// 		TheEnemy.GetComponent<BotAlphaPathing>().enableNavMesh();
	// 	}
	// }
}
