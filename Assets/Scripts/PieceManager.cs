using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour {

	public int numCastle = 1;
	public int numTower = 2;
	public int numPath = 20;

	private bool placable = false;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	public void PlacePieces(bool active) {
		placable = active;
		if(placable){
			GameObject board = FindGameObjectWithTag("Board");
			for(int i = 0; i < board.transform.childCount(); i++){
				TileManager tileManager = board.transform.GetChild(i).gameObject.GetComponent<TileManager>();
				tileManager.clickable = active;
			}
		}
	}
}
