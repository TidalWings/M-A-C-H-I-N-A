using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour {
	[SerializeField] private GameObject[] TextBox;
	int i = 0;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			//while count < TextBox.size()
			//setActive textbox[i]
			//i++
			while (i < TextBox.Length) {
				GameObject infobox = TextBox [i];
				infobox.SetActive (true);

			}
		}
	}
	public void NextWindow() {
		i++;
	}
}
