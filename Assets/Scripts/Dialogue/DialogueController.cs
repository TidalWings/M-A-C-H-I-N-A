using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//must be attached to object that triggers dialogue
public class DialogueController : MonoBehaviour {
	[SerializeField] private GameObject textbox;  //popup window for dialogue
	//popup must have: button, text(name), text(sentence)

	public Dialogue dialogue;
	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			//while count < TextBox.size()
			textbox.SetActive(true);  //opens popup
			//i++
			Debug.Log("talk");
			FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
		}
	}
	public void Ender() {
		textbox.SetActive (false); //closed popup called by Manager when queue is empty
		gameObject.SetActive (false); // deactivates dialogue trigger
	}
}
