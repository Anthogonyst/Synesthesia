using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrapMenu : MonoBehaviour {

	[SerializeField] public int index = 1;

	public void NextButton()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
	}

	public void LoadScene() {
		SceneManager.LoadScene(index, LoadSceneMode.Single);
	}
	
	public void LoadScene(int input) {
		SceneManager.LoadScene(input, LoadSceneMode.Single);
	}

	public void QuitButton()
	{
		Application.Quit();
	}
}
