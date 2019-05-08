using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWorldPushOff : MonoBehaviour {
	private GameObject ActualPlayer;

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Player") {
			ActualPlayer = other.gameObject;
			ActualPlayer.GetComponent<MainPlayer>().disableNavMesh();

			StartCoroutine(SmoothTransition());
		}
	}

    IEnumerator SmoothTransition() {
		// TODO: If the Player isn't falling re-enable NavMesh
        yield return new WaitForSeconds(1.5f);
		if (!(ActualPlayer.transform.position.y <= 4.5)) {
			ActualPlayer.GetComponent<MainPlayer>().enableNavMesh();
		}
	}
}
