using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int health = 100;
	public int damageTaken = 20;
	public int pointsPerKill = 20;

	public void subtractHealth()
	{
		health -= damageTaken;

		if (health <= 0)
			EnemyDie();
	}

	void EnemyDie()
	{
		ScoreManager.instance.AddScore(pointsPerKill);
		Destroy(gameObject);
	}
}
