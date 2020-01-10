using UnityEngine;
using UnityEngine.Events;

public class TileController : MonoBehaviour
{
	public UnityAction Clicked = delegate {};
	new protected Renderer renderer;
	public int semitone;
	
	public static TileController lastClicked	{ get; protected set; }

	protected virtual void OnMouseDown()
	{
		lastClicked =	this;
		Clicked.Invoke();
	}
}
