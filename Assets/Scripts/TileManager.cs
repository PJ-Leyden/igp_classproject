using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public bool clickable = false;
	public int type = 0;
	public GameObject[] pTiles;
	GameObject tile;

	BoardManager bm;

	// Use this for initialization
	void Start () {
		bm = GetComponent<BoardManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if(clickable){
			switch(type){
				case 0://castle
					tile = Instantiate(pTiles[type], transform.position, Quaternion.identity) as GameObject;
					break;

				case 1://tower low
					tile = Instantiate(pTiles[type], transform.position, Quaternion.identity) as GameObject;
					break;

				case 2://tower high
					tile = Instantiate(pTiles[type], transform.position, Quaternion.identity) as GameObject;
					break;

				//case 3://path
					//Instantiate(pTiles[type], transform.position, Quaternion.identity);
					//break;
			}
			clickable = false;
		}
	}
}
