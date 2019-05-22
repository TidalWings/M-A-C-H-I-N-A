using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerSpecial : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	private Queue<string> info;
	// Use this for initialization
	void Start () {
		info = new Queue<string> ();
	}

	public void StartDialogue (Dialogue dialogue) {
		Debug.Log ("start" + dialogue.name);

		nameText.text = dialogue.name;

		info.Clear ();
		foreach (string sentence in dialogue.sentences) {
			info.Enqueue (sentence);
		}
		DisplayNextSentence ();
	}
	public void DisplayNextSentence ()
	{
		if (info.Count == 0)
		{
			EndDialogue ();
			return;
		}

		string sentence = info.Dequeue ();
		dialogueText.text = sentence;
	}
	void EndDialogue() {
		FindObjectOfType<DialogueControllerSpecial> ().Ender (); 
		Debug.Log ("End of Dialogue");
	}
}
