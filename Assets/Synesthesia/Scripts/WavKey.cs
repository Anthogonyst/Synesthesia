using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piano/WavKey", fileName = "WavList")]
public class WavKey : ScriptableObject {
	// Text box for writing notes
    [TextArea(3, 6)]
    [SerializeField] string personalNotes;
	
	// Sound clip data
    [Tooltip("Defines the sound file for an octave. Please order from Asharp and up.")]
    [SerializeField] AudioClip[] sound;
	
    public virtual string Description
    {
        get { return personalNotes; }
    }

    public virtual AudioClip[] AudioClip
    {
        get { return sound; }
    }
	
	public AudioClip getSound(int n) {
		return sound[n];
	}
	
	public int getSize() {
		return sound.Length;
	}
}
