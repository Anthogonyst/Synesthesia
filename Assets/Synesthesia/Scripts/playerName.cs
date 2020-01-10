using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Piano/Name", fileName = "TheName")]
public class playerName : ScriptableObject {
	
	[TextArea(3, 6)]
	[SerializeField] string description;

	[Tooltip("The name of the player.")]
	[SerializeField] string theOneTrueName;
	
	public void setName(string s) {
		theOneTrueName = s;
		return;
	}
	
	public virtual string getTheName() {
		return theOneTrueName;
	}
}
