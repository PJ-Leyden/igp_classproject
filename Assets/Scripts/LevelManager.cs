using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static LevelManager instance = null;

	public int level;
	public Animator gameCanvas;

	public bool levelOver;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		levelOver = false;
	}



	public void SetGameOver()
	{
		//Start Game Over Animation
		levelOver = true;
		gameCanvas.SetTrigger("GameOver");
		

	}

	public void SetLevelComplete()
	{
		//Start Level Completed Animation
		levelOver = true;
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
		ScoreManager.instance.score = 0;

		//Load Main Menu
		SceneManager.LoadScene("main_menu");

	}
}
