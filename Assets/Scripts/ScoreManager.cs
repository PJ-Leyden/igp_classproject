using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance = null;

	//Total Score of the game
	public int score;
	public Text scoreText;

	private void Start()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		UpdateScoreText();
	}


	//Add to the score
	public void AddScore(int points)
	{
		score += points;
		UpdateScoreText();
		//Debug.Log(score);
	}

	//Subtract from the score
	public void SubtractScore(int points)
	{
		score -= points;
		UpdateScoreText();
	}

	void UpdateScoreText()
	{
		scoreText.text = "Score: " + score;
	}

}
