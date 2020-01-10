using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGenerator : MonoBehaviour {

	/*[System.Serializable]
	private class _PianoKey
	{
		// To be implemented in future
		// private MidiController midi;
		public GameObject key;
		public int semitone;
	}*/
	
	// Inspector variables
	public WavKey octave;
	public GameObject whiteKey;
	public GameObject blackKey;
	public GameObject backgroundTile;
	public int numberOfKeys = 20;
	public float widthOfKey = 1f;
	public float heightOfKey = 4f;
	public int offset = 50;
	public bool thirteenthKey = true; // i got lazy
	
	// Helper variable
	private float position = 0f;
	//private List<_PianoKey> pianoKeys;
	
	// Assigns values to notes for readability
	// !! Order sensitive so do not change !!
	// Middle C = 50
	private enum pitch { Asharp, B, C, Csharp, D, Dsharp, E, F, Fsharp, G, Gsharp, A };
	// Not sure why C# wanted me to hard-cast everything...
	private int[] natural = { (int)pitch.A, (int)pitch.B, (int)pitch.C, (int)pitch.D, (int)pitch.E, (int)pitch.F, (int)pitch.G };
	//private int[] sharp = { (int)pitch.Asharp, (int)pitch.Csharp, (int)pitch.Dsharp, (int)pitch.Fsharp, (int)pitch.Gsharp };
	
	// Use this for initialization
	void Start () {
		// Checks for all 12 sounds
		if (octave.getSize() < 12) {
			Debug.Log("Error getting sound data. Array less than 12.");
			return;
		}
		
		// Makes empty background tile if non-existent
		if (backgroundTile == null) {
			backgroundTile = new GameObject();
		}
		
		//pianoKeys = new List<_PianoKey>();
		
		// Pushes piano left and spawns left to right
		position -= numberOfKeys * 7/12 * widthOfKey;
		
		// Begins spawning the keys
		for (int i = -numberOfKeys; i < numberOfKeys; i++) {
			Spawn(i);
		}
		
		// Temporary until refactor
		if (thirteenthKey) {
			Spawn(6);
		}
	}
	
	void Spawn(int n) {
		// Initializes semitone and position
		int st = n + offset;
		Vector3 localPos = new Vector3(position * widthOfKey, 0, 0);
		GameObject k;
		
		// If natural, creates a white key and a wooden tile
		if (IsNatural(st)) {
			k = Instantiate(whiteKey, transform.TransformPoint(localPos), Quaternion.identity, transform);
			Instantiate(backgroundTile, transform.TransformPoint(localPos), Quaternion.identity, transform);
			position += widthOfKey;
		} else // If sharp/flat, creates a black key
		{
			localPos += new Vector3(-Mathf.Pow(widthOfKey, 2)/2, heightOfKey, -0.5f);
			k = Instantiate(blackKey, transform.TransformPoint(localPos), Quaternion.identity, transform);
		}

		// Set controller semitone
		if (k.GetComponent<TileController>() != null)
			k.GetComponent<TileController>().semitone = st;
		
		// Temporary fix until refactor
		if (thirteenthKey && n == 6) {
			AudioSource hz = k.AddComponent(typeof(AudioSource)) as AudioSource;
			hz.clip = octave.getSound(12);
		} else {  // Normal code
		// Allocates the audio clip to each key and adjusts the pitch to simulate an octave
		AudioSource hz = k.AddComponent(typeof(AudioSource)) as AudioSource;
		hz.clip = octave.getSound(st % 12);
		hz.pitch = Mathf.Pow(2, Mathf.Floor((st - 2) / 12)) / 16;
		}
	}
	
	// Tests for naturals or sharps
	bool IsNatural(int i) {
		foreach (int n in natural) {
			if (i % 12 == n) {
				// If natural
				return true; 
			}
		}
		// If sharp/flat
		return false;
	}
}
