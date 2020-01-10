using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class _PianoKeyForGame {
	
	public Transform key;
	public int semi;
	
	private SpriteRenderer drawParent;
	private SpriteRenderer drawChild;	
	private Color correct = Color.green;
	private Color wrong = Color.red;
	private Color reset = Color.black;
	private bool ready = false;
	
	public void drawCorrect() {
		drawParent.color = correct;
		drawChild.color = correct;
	}

	public void drawWrong() {
		drawParent.color = wrong;
		drawChild.color = wrong;
	}
	
	public void drawReset() {
		drawParent.color = reset;
		drawChild.color = reset;
	}
	
	public void start() {
		if (ready != true) {
			drawParent = key.GetComponent<SpriteRenderer>();
			drawChild = key.GetChild(0).GetComponent<SpriteRenderer>();
			ready = true;
		}
	}
}