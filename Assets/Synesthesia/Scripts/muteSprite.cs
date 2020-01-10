using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class muteSprite : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public Button button;

    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { changeTheSprite(); });
    }

    void changeTheSprite()
    {
        if (button.image.sprite == sprite1)
            button.image.sprite = sprite2;
        else
            button.image.sprite = sprite1;
    }
	
	public void resetSprite() {
		button.image.sprite = sprite1;
	}
}
