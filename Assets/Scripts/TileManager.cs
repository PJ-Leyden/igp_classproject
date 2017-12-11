using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public bool clickable = false;
	public int type = 0;
	public GameObject[] pTiles;
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
