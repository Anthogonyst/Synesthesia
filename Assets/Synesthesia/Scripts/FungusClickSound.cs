using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusClickSound : MonoBehaviour {

	public Flowchart pcontrol;
	
	private bool safe = false;
	private RaycastHit hit;
	
	void Start() {
		if (pcontrol != null)
			if (pcontrol.GetIntegerVariable("keyPress") != 0)
				if (pcontrol.FindBlock("UpdatePress") != null)
					safe = true;
	}
	
	public void seekKeyAtMouse() {
		// Creates a ray straight out of the camera
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		// If collision is detected, it makes temporary hit data
		if (Physics.Raycast(ray, out hit)){	
			// Draws the ray in inspector for visual debugging
			Debug.DrawLine(ray.origin, hit.point);
			
			// Stores the hit data as a game object
			GameObject other = hit.collider.gameObject;
			
			// Tests if game object is a piano key
			if (other.GetComponent<TileController>() != null) {
				// Since it's a piano key, it plays a sound
				other.GetComponent<AudioSource>().Play();
				fungusMagic(other.GetComponent<TileController>().semitone);
			}
		}
	}
	
	private void fungusMagic(int n) {
		pcontrol.SetIntegerVariable("keyPress", n);
		pcontrol.ExecuteBlock("UpdatePress");
	}
}

