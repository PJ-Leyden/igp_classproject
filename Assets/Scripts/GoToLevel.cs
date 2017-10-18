using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{

	public void LoadLevel(string level)
	{
		Debug.Log(level);
		SceneManager.LoadScene(level);
	}
}
