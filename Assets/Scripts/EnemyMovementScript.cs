using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour {

	public LayerMask blockingLayer;
	public float speed = 0.6f;
	Collider2D prevTile;
	Collider2D nextTile;
	public string straightPathTag = "";
	public string cornerPathTag = "";
	public string castleTag = "";

	bool isMoving;
	bool isDone;
	bool foundCastle;

	// Use this for initialization
	void Start () {
		SetNextTile();
		isMoving = true;
		isDone = false;
		foundCastle = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDone  && !LevelManager.instance.levelOver)
		{
			if (transform.position != nextTile.transform.position)
			{
				isMoving = true;
				Vector2 newPosition = Vector2.MoveTowards(transform.position, nextTile.transform.position, speed);
				GetComponent<Rigidbody2D>().MovePosition(newPosition);
			}
			else
			{
				isMoving = false;
				if(foundCastle)
				{
					isDone = true;
					LevelManager.instance.SetGameOver();
				}
			}

			if (!isMoving && !foundCastle)
			{
				SetNextTile();
				isMoving = true;
			}

		}


	}


	void SetNextTile()
	{
		Vector2 nextPosition;
		Collider2D tempTile;

		//Check above
		nextPosition = (Vector2)transform.position;
		tempTile = GetTile(nextPosition + Vector2.up);
		//Check Right
		if(tempTile == null || tempTile == prevTile)
			tempTile = GetTile(nextPosition + Vector2.right);
		//Check Down
		if (tempTile == null || tempTile == prevTile)
			tempTile = GetTile(nextPosition + Vector2.down);
		//Check Left
		if (tempTile == null || tempTile == prevTile)
			tempTile = GetTile(nextPosition + Vector2.left);

		//isDone
		if (tempTile == null || tempTile == prevTile)
			isDone = true;

		prevTile = nextTile;
		nextTile = tempTile;


	}

	Collider2D GetTile(Vector2 nextPosition)
	{
		Collider2D tempTile;

		tempTile = Physics2D.OverlapPoint(nextPosition, blockingLayer);

		//Set to null if not a path tile
		if (tempTile != null)
		{
			if (tempTile.CompareTag(castleTag))
			{
				foundCastle = true;
				Debug.Log("Found");
			}

			if (!tempTile.CompareTag(straightPathTag) && !tempTile.CompareTag(cornerPathTag) && !tempTile.CompareTag(castleTag))
				tempTile = null;
		}




		return tempTile;
	}
}
