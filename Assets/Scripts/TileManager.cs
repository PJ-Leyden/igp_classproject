using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public bool clickable = false;
	public int type = 0;
	public GameObject[] pTiles;
	public LayerMask blockingLayer;
	GameObject tile;

	GameObject gm;
	PieceManager pm;



	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("Game Manager");
		pm = gm.GetComponent<PieceManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if(clickable){

			//here
			int isJunction = 0;
			Collider2D temp;

			if(type == 3 || type == 4){
				//Check Top
				temp = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.up, blockingLayer);
				if(temp != null){
					if(temp.CompareTag("StraightPathTile") || temp.CompareTag("Start Tile")){
						isJunction++;
					}
				}
				//Check Top Right
				temp = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.up + Vector2.right, blockingLayer);
				if(temp != null){
					if(temp.CompareTag("StraightPathTile") || temp.CompareTag("Start Tile")){
						isJunction++;
					}
				}
				//Check Top Left
				temp = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.up + Vector2.left, blockingLayer);
				if(temp != null){
					if(temp.CompareTag("StraightPathTile") || temp.CompareTag("Start Tile")){
						isJunction++;
					}
				}
				//Check Left
				temp = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.left, blockingLayer);
				if(temp != null){
					if(temp.CompareTag("StraightPathTile") || temp.CompareTag("Start Tile")){
						isJunction++;
					}
				}
				//Check Right
				temp = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.right, blockingLayer);
				if(temp != null){
					if(temp.CompareTag("StraightPathTile") || temp.CompareTag("Start Tile")){
						isJunction++;
					}
				}
				//Check Bottom
				temp = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.down, blockingLayer);
				if(temp != null){
					if(temp.CompareTag("StraightPathTile") || temp.CompareTag("Start Tile")){
						isJunction++;
					}
				}
				//Check Bottom Left
				temp = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.down + Vector2.left, blockingLayer);
				if(temp != null){
					if(temp.CompareTag("StraightPathTile") || temp.CompareTag("Start Tile")){
						isJunction++;
					}
				}
				//Check Bottom Right
				temp = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.down + Vector2.right, blockingLayer);
				if(temp != null){
					if(temp.CompareTag("StraightPathTile") || temp.CompareTag("Start Tile")){
						isJunction++;
					}
				}
			}

			if(isJunction < 3){
				switch(type){
					case 0://castle
						if(pm.numCastle > 0){
							tile = Instantiate(pTiles[type], transform.position, Quaternion.identity) as GameObject;
							pm.numCastle--;
						}
						break;

					case 1://tower low
						if(pm.numTower1 > 0){
							tile = Instantiate(pTiles[type], transform.position, Quaternion.identity) as GameObject;
							pm.numTower1--;
						}
						break;

					case 2://tower high
						if(pm.numTower2 > 0){
							tile = Instantiate(pTiles[type], transform.position, Quaternion.identity) as GameObject;
							pm.numTower2--;
						}
						break;

					case 3://path
						if(pm.numPath > 0){
							tile = Instantiate(pTiles[type], transform.position, Quaternion.identity) as GameObject;
							pm.numPath--;
						}
						break;

					case 4:
						if(pm.numStart > 0){
							tile = Instantiate(pTiles[type], transform.position, Quaternion.identity) as GameObject;
							pm.numStart--;
						}
						break;
				}
				pm.UpdateText();
				clickable = false;	
			}
		}
	}
}	
