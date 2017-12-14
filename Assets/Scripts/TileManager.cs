using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public bool clickable = false;
	public int type = 4;
	public GameObject[] pTiles;
	public LayerMask blockingLayer;
	public LayerMask moveLayer;
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
			TileManager tileManager;
			Collider2D nextPos;
			Collider2D temp1, temp2, temp3;
			bool x = false, y = false, z = false;

			/*if(type == 3 || type == 4){
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
			}*/

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
							pm.PlacePieces(false);
							for(int i = 0; i < 4; i++){//check adjacent blocks
								switch(i){
									case 0://up
										x = false;
										y = false;
										z = false;
										nextPos = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.up, blockingLayer);//get collider for up space
										if(nextPos != null){
											if(!nextPos.CompareTag("StraightPathTile") && !nextPos.CompareTag("Start Tile")){
												temp1 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.up, moveLayer);	
												temp2 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.right, moveLayer);
												temp3 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.left, moveLayer);
												if(temp1 != null){
													if(!temp1.CompareTag("StraightPathTile") && !temp1.CompareTag("Start Tile")){
														x = true;
													}
												}else{
													x = true;
												}
												if(temp2 != null){
													if(!temp2.CompareTag("StraightPathTile") && !temp2.CompareTag("Start Tile")){
														y = true;
													}
												}else{
													y = true;
												}
												if(temp3 != null){
													if(!temp3.CompareTag("StraightPathTile") && !temp3.CompareTag("Start Tile")){
														z = true;
													}
												}else{
													z = true;
												}

												if(x && y && z && !nextPos.CompareTag("Lake Tile") && !nextPos.CompareTag("Mountain Tile")){
													tileManager = nextPos.gameObject.GetComponent<TileManager>();
													tileManager.clickable = true;
												}
											}
										}
										break;

									case 1://right
										x = false;
										y = false;
										z = false;
										nextPos = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.right, blockingLayer);//get collider for up space
										if(nextPos != null){
											if(!nextPos.CompareTag("StraightPathTile") && !nextPos.CompareTag("Start Tile")){
												temp1 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.up, moveLayer);	
												temp2 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.right, moveLayer);
												temp3 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.down, moveLayer);
												if(temp1 != null){
													if(!temp1.CompareTag("StraightPathTile") && !temp1.CompareTag("Start Tile")){
														x = true;
													}
												}else{
													x = true;
												}
												if(temp2 != null){
													if(!temp2.CompareTag("StraightPathTile") && !temp2.CompareTag("Start Tile")){
														y = true;
													}
												}else{
													y = true;
												}
												if(temp3 != null){
													if(!temp3.CompareTag("StraightPathTile") && !temp3.CompareTag("Start Tile")){
														z = true;
													}
												}else{
													z = true;
												}

												if(x && y && z && !nextPos.CompareTag("Lake Tile") && !nextPos.CompareTag("Mountain Tile")){
													tileManager = nextPos.gameObject.GetComponent<TileManager>();
													tileManager.clickable = true;
												}
											}
										}
										break;

									case 2://left
										x = false;
										y = false;
										z = false;
										nextPos = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.left, blockingLayer);//get collider for up space
										if(nextPos != null){
											if(!nextPos.CompareTag("StraightPathTile") && !nextPos.CompareTag("Start Tile")){
												temp1 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.up, moveLayer);	
												temp2 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.down, moveLayer);
												temp3 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.left, moveLayer);
												if(temp1 != null){
													if(!temp1.CompareTag("StraightPathTile") && !temp1.CompareTag("Start Tile")){
														x = true;
													}
												}else{
													x = true;
												}
												if(temp2 != null){
													if(!temp2.CompareTag("StraightPathTile") && !temp2.CompareTag("Start Tile")){
														y = true;
													}
												}else{
													y = true;
												}
												if(temp3 != null){
													if(!temp3.CompareTag("StraightPathTile") && !temp3.CompareTag("Start Tile")){
														z = true;
													}
												}else{
													z = true;
												}

												if(x && y && z && !nextPos.CompareTag("Lake Tile") && !nextPos.CompareTag("Mountain Tile")){
													tileManager = nextPos.gameObject.GetComponent<TileManager>();
													tileManager.clickable = true;
												}
											}
										}
										break;

									case 3://down
										x = false;
										y = false;
										z = false;
										nextPos = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.down, blockingLayer);//get collider for up space
										if(nextPos != null){
											if(!nextPos.CompareTag("StraightPathTile") && !nextPos.CompareTag("Start Tile")){
												temp1 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.down, moveLayer);	
												temp2 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.right, moveLayer);
												temp3 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.left, moveLayer);
												if(temp1 != null){
													if(!temp1.CompareTag("StraightPathTile") && !temp1.CompareTag("Start Tile")){
														x = true;
													}
												}else{
													x = true;
												}
												if(temp2 != null){
													if(!temp2.CompareTag("StraightPathTile") && !temp2.CompareTag("Start Tile")){
														y = true;
													}
												}else{
													y = true;
												}
												if(temp3 != null){
													if(!temp3.CompareTag("StraightPathTile") && !temp3.CompareTag("Start Tile")){
														z = true;
													}
												}else{
													z = true;
												}

												if(x && y && z && !nextPos.CompareTag("Lake Tile") && !nextPos.CompareTag("Mountain Tile")){
													tileManager = nextPos.gameObject.GetComponent<TileManager>();
													tileManager.clickable = true;
												}
											}
										}
										break;
								}
							}
						}
						break;

					case 4://start
						if(pm.numStart > 0){
							tile = Instantiate(pTiles[type], transform.position, Quaternion.identity) as GameObject;
							pm.numStart--;
							pm.PlacePieces(false);
							for(int i = 0; i < 4; i++){//check adjacent blocks
								switch(i){
									case 0://up
										x = false;
										y = false;
										z = false; 
										nextPos = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.up, blockingLayer);//get collider for up space
										if(nextPos != null){
											if(!nextPos.CompareTag("StraightPathTile") && !nextPos.CompareTag("Start Tile")){
												temp1 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.up, moveLayer);	
												temp2 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.right, moveLayer);
												temp3 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.left, moveLayer);
												if(temp1 != null){
													if(!temp1.CompareTag("StraightPathTile") && !temp1.CompareTag("Start Tile")){
														x = true;
													}
												}else{
													x = true;
												}
												if(temp2 != null){
													if(!temp2.CompareTag("StraightPathTile") && !temp2.CompareTag("Start Tile")){
														y = true;
													}
												}else{
													y = true;
												}
												if(temp3 != null){
													if(!temp3.CompareTag("StraightPathTile") && !temp3.CompareTag("Start Tile")){
														z = true;
													}
												}else{
													z = true;
												}

												if(x && y && z && !nextPos.CompareTag("Lake Tile") && !nextPos.CompareTag("Mountain Tile")){
													tileManager = nextPos.gameObject.GetComponent<TileManager>();
													tileManager.clickable = true;
												}
											}
										}
										break;

									case 1://right
										x = false;
										y = false;
										z = false;
										nextPos = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.right, blockingLayer);//get collider for up space
										if(nextPos != null){
											if(!nextPos.CompareTag("StraightPathTile") && !nextPos.CompareTag("Start Tile")){
												temp1 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.up, moveLayer);	
												temp2 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.right, moveLayer);
												temp3 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.down, moveLayer);
												if(temp1 != null){
													if(!temp1.CompareTag("StraightPathTile") && !temp1.CompareTag("Start Tile")){
														x = true;
													}
												}else{
													x = true;
												}
												if(temp2 != null){
													if(!temp2.CompareTag("StraightPathTile") && !temp2.CompareTag("Start Tile")){
														y = true;
													}
												}else{
													y = true;
												}
												if(temp3 != null){
													if(!temp3.CompareTag("StraightPathTile") && !temp3.CompareTag("Start Tile")){
														z = true;
													}
												}else{
													z = true;
												}

												if(x && y && z && !nextPos.CompareTag("Lake Tile") && !nextPos.CompareTag("Mountain Tile")){
													tileManager = nextPos.gameObject.GetComponent<TileManager>();
													tileManager.clickable = true;
												}
											}
										}
										break;

									case 2://left
										x = false;
										y = false;
										z = false;
										nextPos = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.left, blockingLayer);//get collider for up space
										if(nextPos != null){
											if(!nextPos.CompareTag("StraightPathTile") && !nextPos.CompareTag("Start Tile")){
												temp1 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.up, moveLayer);	
												temp2 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.down, moveLayer);
												temp3 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.left, moveLayer);
												if(temp1 != null){
													if(!temp1.CompareTag("StraightPathTile") && !temp1.CompareTag("Start Tile")){
														x = true;
													}
												}else{
													x = true;
												}
												if(temp2 != null){
													if(!temp2.CompareTag("StraightPathTile") && !temp2.CompareTag("Start Tile")){
														y = true;
													}
												}else{
													y = true;
												}
												if(temp3 != null){
													if(!temp3.CompareTag("StraightPathTile") && !temp3.CompareTag("Start Tile")){
														z = true;
													}
												}else{
													z = true;
												}

												if(x && y && z && !nextPos.CompareTag("Lake Tile") && !nextPos.CompareTag("Mountain Tile")){
													tileManager = nextPos.gameObject.GetComponent<TileManager>();
													tileManager.clickable = true;
												}
											}
										}
										break;

									case 3://down
										x = false;
										y = false;
										z = false;
										nextPos = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.down, blockingLayer);//get collider for up space
										if(nextPos != null){
											if(!nextPos.CompareTag("StraightPathTile") && !nextPos.CompareTag("Start Tile")){
												temp1 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.down, moveLayer);	
												temp2 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.right, moveLayer);
												temp3 = Physics2D.OverlapPoint((Vector2)nextPos.transform.position + Vector2.left, moveLayer);
												if(temp1 != null){
													if(!temp1.CompareTag("StraightPathTile") && !temp1.CompareTag("Start Tile")){
														x = true;
													}
												}else{
													x = true;
												}
												if(temp2 != null){
													if(!temp2.CompareTag("StraightPathTile") && !temp2.CompareTag("Start Tile")){
														y = true;
													}
												}else{
													y = true;
												}
												if(temp3 != null){
													if(!temp3.CompareTag("StraightPathTile") && !temp3.CompareTag("Start Tile")){
														z = true;
													}
												}else{
													z = true;
												}

												if(x && y && z && !nextPos.CompareTag("Lake Tile") && !nextPos.CompareTag("Mountain Tile")){
													tileManager = nextPos.gameObject.GetComponent<TileManager>();
													tileManager.clickable = true;
												}
											}
										}
										break;
								}
							}
						}
						break;
				}
				pm.UpdateText();
				clickable = false;			
			}
		}
	}
}	
