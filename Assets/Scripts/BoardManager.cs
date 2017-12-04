using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	[Serializable]
	public class Count {
		public int minimum;
		public int maximum;

		public Count(int min, int max) {
			minimum = min;
			maximum = max;
		}
	}

	public int columns = 7;
	public int rows = 7;
	public Count forestCount = new Count (5, 7);
	public Count lakeCount = new Count (1, 3);
	public Count mountainCount = new Count (1, 3);
	public GameObject[] grass_tiles;
	public GameObject[] lake_tiles;
	public GameObject[] mountain_tiles;
	public GameObject[] forest_tiles;

	private GameObject board;
	private Transform boardHolder;
	private List <Vector3> gridPositions = new List<Vector3>();

	void InitializeList() {
		gridPositions.Clear();
		for(int x = 0; x < columns; x++){
			for(int y = 0; y < rows; y++){
				gridPositions.Add(new Vector3(x, y, 0f));
			}
		}
	}

	void BoardSetup() {
		board = new GameObject("Board");
		boardHolder = board.transform;
		board.tag = "Board";
	}

	Vector3 RandomPosition() {
		int randomIndex = Random.Range(0, gridPositions.Count);  
		Vector3 randomPosition = gridPositions[randomIndex];   
		gridPositions.RemoveAt(randomIndex);
		return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum) {
    	int objectCount = Random.Range(minimum, maximum + 1);
    	for(int i = 0; i < objectCount; i++){
    		Vector3 randomPosition = RandomPosition();
    		GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
    		GameObject instance = Instantiate(tileChoice, randomPosition, Quaternion.identity) as GameObject;
    		instance.transform.SetParent(boardHolder);
    	}
    }

    void FillBoard(GameObject[] tileArray) {
    	for(int i = 0; i < gridPositions.Count; i++){
    		Vector3 curPosition = gridPositions[i];
    		GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
    		GameObject instance = Instantiate(tileChoice, curPosition, Quaternion.identity) as GameObject;
    		instance.transform.SetParent(boardHolder);
    	}
    }

    public void SetupScene(int level) {
    	BoardSetup();
    	InitializeList();
    	LayoutObjectAtRandom(lake_tiles, lakeCount.minimum, lakeCount.maximum);
    	LayoutObjectAtRandom(forest_tiles, forestCount.minimum, forestCount.maximum);
    	LayoutObjectAtRandom(mountain_tiles, mountainCount.minimum, mountainCount.maximum);
    	FillBoard(grass_tiles);
    }
}
