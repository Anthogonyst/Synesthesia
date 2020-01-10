using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notesList : MonoBehaviour {

	public List<_PianoKeyForGame> staffNotes;
	
	private int count;
	private int current = 0;
	
	// Use this for initialization
	void Start () {
		foreach (_PianoKeyForGame p in staffNotes) {
			p.start();
		}
		count = staffNotes.Count;
	}
	
	
	public bool scoreNote(int n) {
		if (current < count) {
			if (staffNotes[current].semi == n) {
				staffNotes[current].drawCorrect();
				current++;
				return true;
			} else {
				staffNotes[current].drawWrong();
				current++;
				return false;
			}
		}
		
		// current >= count
		return false;
	}
	
	public void resetNotes() {
		foreach (_PianoKeyForGame p in staffNotes) {
			p.drawReset();
		}
		current = 0;
	}
}
