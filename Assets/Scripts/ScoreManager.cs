using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

	//Total Score of the game
	public static int score;
	public Text scoreText;


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
