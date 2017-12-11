using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceManager : MonoBehaviour {

	public int numCastle = 1;
	public Text castle;
	public int numTower1 = 2;
	public Text tower1;
	public int numTower2 = 1;
	public Text tower2;
	public int numPath = 20;
	public Text path;
	public int numStart = 1;
	public Text start;

	private bool placable = false;

	// Use this for initialization
	void Start() {
		UpdateText();
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	public void PlacePieces(int type) {
		placable = true;
		if(placable){
			GameObject board = GameObject.FindGameObjectWithTag("Board");
			for(int i = 0; i < board.transform.childCount; i++){
				if(!board.transform.GetChild(i).gameObject.CompareTag("Lake Tile") && !board.transform.GetChild(i).gameObject.CompareTag("Mountain Tile")){
					TileManager tileManager = board.transform.GetChild(i).gameObject.GetComponent<TileManager>();
					tileManager.clickable = true;
					tileManager.type = type;
				}
			}
		}
	}

	public void UpdateText() {
		castle.text = "" + numCastle;
		tower1.text = "" + numTower1;
		tower2.text = "" + numTower2;
		path.text   = "" + numPath;
		start.text  = "" + numStart;
	}
}
