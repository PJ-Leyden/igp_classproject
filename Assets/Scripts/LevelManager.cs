using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public int level;
	public Animator gameCanvas;



	public void SetGameOver()
	{
		//Start Game Over Animation
		gameCanvas.SetTrigger("GameOver");

	}

	public void SetLevelComplete()
	{
		//Start Level Completed Animation
		gameCanvas.SetTrigger("LevelCompleted");
	}

	public void GoToNextLevel()
	{
		//Increment Level
		level++;

		//Load New Scence
		SceneManager.LoadScene("main_board");
	}

	public void GoToMainMenu()
	{
		//Reset Level
		level = 1;

		//Reset Score
		ScoreManager.score = 0;

		//Load Main Menu
		SceneManager.LoadScene("main_menu");

	}
}
