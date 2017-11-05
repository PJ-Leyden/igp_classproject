using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public int level;



	public void SetGameOver()
	{
		//Start Game Over Animation

		level = 1;

		//Load Main Menu
		SceneManager.LoadScene("main_menu");
	}

	public void SetLevelComplete()
	{
		//Start Level Completed Animation

		level++;

		//Load New Scence
		SceneManager.LoadScene("main_board");
	}
}
