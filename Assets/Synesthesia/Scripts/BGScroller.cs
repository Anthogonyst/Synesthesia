using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
	public float scrollSpeed;
	public float tileSizeZ;
    int count = 0;
	private Vector3 startPosition;

	void Start ()
	{
		startPosition = transform.position;
	}

	void Update ()
	{

        if (count < 1000)
        {
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
            transform.position = startPosition + Vector3.up * newPosition;
            count++;
        }
      
            
	}
}
	