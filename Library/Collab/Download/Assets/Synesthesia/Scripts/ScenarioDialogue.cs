using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Piano/Dialogue", fileName = "NewDialogue")]
public class ScenarioDialogue : ScriptableObject
{
	[TextArea(3, 6)]
	[SerializeField] string description;

	[Tooltip("A list of dialogues.")]
	[SerializeField] Dialogue phrases;

	public virtual string Description 
	{
		get { return description; }
	}

	public virtual Dialogue Dialogue
	{
		get { return phrases; }
	}
}