using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAggro : MonoBehaviour {
	public GameObject father;
	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			father.GetComponent<BotAlphaPathing>().setAggro();
		}
	}
}
