using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public Transform center;
	public Transform cannonEnd;

	private Vector2 centerPos;
	private Vector2 cannonEndPos;
	private Quaternion myRotation;

	// Use this for initialization
	void Start () {
		centerPos = center.position;
		cannonEndPos = cannonEnd.position;

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("Center: " + centerPos);
		Vector2 enemyPos = GameObject.FindGameObjectsWithTag("Enemy")[0].transform.position;
		Vector2 dirToEnemy = enemyPos - centerPos;
		Vector2 dirOfCannon = cannonEndPos - centerPos;

		myRotation.SetFromToRotation(dirOfCannon, dirToEnemy);
		transform.rotation = myRotation;
	}
}
