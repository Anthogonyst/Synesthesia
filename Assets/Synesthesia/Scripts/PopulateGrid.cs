using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
	public GameObject prefab; // This is our prefab object that will be exposed in the inspector
	public List<Sprite> pictures;
	
	public int numberToCreate; // number of objects to create. Exposed in inspector

	void Start()
	{
		if (pictures.Count < 1 || prefab == null) return;
		
		if (pictures.Count == numberToCreate) {
			staticPopulate();
		} else Populate();
	}
	
	void Populate()
	{
		for (int i = 0; i < numberToCreate; i++)
		{
			 // Create new instances of our prefab until we've created as many as we specified
			GameObject newObj = (GameObject)Instantiate(prefab, transform);
			
			// Randomize the color of our image
			newObj.GetComponent<Image>().color = Random.ColorHSV(); 
		}
	}
	
	void staticPopulate() {
		for (int i = 0; i < numberToCreate; i++)
		{
			GameObject newObj;
			 // Create new instances of our prefab until we've created as many as we specified
			newObj = (GameObject)Instantiate(prefab, transform);
			
			// Change picture
			newObj.GetComponent<Image>().sprite = pictures[i];
		}
	}
}