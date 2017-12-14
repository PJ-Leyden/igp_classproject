using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private BoardManager boardScript;
	private PieceManager pieceManager;

	private int level = 1;

	public int numEnemies = 10;

	GameObject startTile;
	public GameObject enemy;

	public Button reset;


	// Use this for initialization
	void Awake () {
		reset.enabled = true;
		boardScript = GetComponent<BoardManager>();
		pieceManager = GetComponent<PieceManager>();
		InitGame();
		PlacePieces();
	}

	void InitGame() {
		boardScript.SetupScene(level);
	}

	void PlacePieces() {
		pieceManager.PlacePieces(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (!LevelManager.instance.levelOver)
			if (numEnemies < 1 && GameObject.FindGameObjectsWithTag("Enemy").Length < 1)
				LevelManager.instance.SetLevelComplete();
	}

	public void beginGame(){
		reset.enabled = false;
		startTile = GameObject.FindGameObjectWithTag("Start Tile");
		InvokeRepeating("spawnEnemy", 1, 1f);
	}

	public void spawnEnemy(){
		Instantiate(enemy, startTile.transform.position, Quaternion.identity);
		--numEnemies;
		if(numEnemies < 1 || LevelManager.instance.levelOver){
			CancelInvoke();
		}
	}
}
