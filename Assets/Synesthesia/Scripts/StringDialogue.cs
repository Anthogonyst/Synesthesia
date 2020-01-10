using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piano/DialogueSet", fileName = "NewStringArray")]
public class StringDialogue : ScriptableObject
{
	[TextArea(3, 6)]
	[SerializeField] string description;

	[Tooltip("A list of dialogues.")]
	[SerializeField] string[] dialogue;

	public virtual string Description 
	{
		get { return description; }
	}

	public virtual string[] Dialogue
	{
		get { return dialogue; }
	}
}
