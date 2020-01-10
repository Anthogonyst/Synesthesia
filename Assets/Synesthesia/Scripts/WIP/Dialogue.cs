using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Piano/DialoguePiece", fileName = "NewDialogue")]
public class Dialogue : ScriptableObject {
	
	[SerializeField] public List<DialogueSet> speech = new List<DialogueSet>();
	
	string say(string s, int index) {
		foreach (DialogueSet d in speech) {
			if (index < d.say.Count && s == d.callName)
				return d.say[index];
		}
		return null;
	}

	AudioClip talk(string s, int index) {
		foreach (DialogueSet d in speech) {
			if (index < d.talk.Count && s == d.callName)
				return d.talk[index];
		}
		return null;
	}
	
	int getLength(string s) {
		foreach (DialogueSet d in speech) {
			if (s == d.callName)
				return Mathf.Max(d.say.Count, d.talk.Count);
		}
		return -1;
	}
}
