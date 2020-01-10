using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClickSound : MonoBehaviour {

	private RaycastHit hit;
	
	void Update() {
		// If left mouse button pressed
		if (Input.GetMouseButtonDown(0)) { 
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
				}
			}
		}
	}
}
