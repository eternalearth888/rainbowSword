using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
	public void PlayGame()
	{
		SceneManager.LoadScene("WorldScene");
	}

    public void QuitToTitle()
	{
		SceneManager.LoadScene("TitleScene");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
