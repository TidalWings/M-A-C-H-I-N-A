using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour {
	[SerializeField] GameObject enemy;


	public void OnMouseDown() {

		Destroy (enemy);

		Debug.Log("Wow 1 Hit KO, you're really strong!");	
	}

}
	
