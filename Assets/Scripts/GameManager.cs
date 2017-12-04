using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private BoardManager boardScript;
	private PieceManager pieceManager;


	private int level = 1;

	// Use this for initialization
	void Awake () {
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
		
	}
}
