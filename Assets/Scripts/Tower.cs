using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public Transform center;
	public Transform cannonEnd;
	public GameObject bullet;
	public float bulletSpeed;
	public float shootTimer;

	private Vector2 centerPos;
	private Vector2 cannonEndPos;
	private Quaternion myRotation;
	private float shootTimeLeft;

	// Use this for initialization
	void Start () {
		centerPos = center.position;
		cannonEndPos = cannonEnd.position;
		shootTimeLeft = shootTimer;

	}

	// Update is called once per frame
	void Update() {
		Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);

		if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0 && !LevelManager.instance.levelOver)
		{
			Rotate();
			ShootControl();
		}
	}

	private void Rotate()
	{
		//Debug.Log("Center: " + centerPos);
		//int index = GameObject.FindGameObjectsWithTag("Enemy").Length - 1;
		int index = 0;
		Vector2 enemyPos = GameObject.FindGameObjectsWithTag("Enemy")[index].transform.position;
		Vector2 dirToEnemy = enemyPos - centerPos;
		Vector2 dirOfCannon = cannonEndPos - centerPos;

		myRotation.SetFromToRotation(dirOfCannon, dirToEnemy);
		transform.rotation = myRotation;
	}

	private void Shoot()
	{
		GameObject myBullet = Instantiate(bullet, cannonEnd.position, Quaternion.identity);

		myBullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
	}

	private void ShootControl()
	{
		if (shootTimeLeft > 0)
		{
			shootTimeLeft -= Time.deltaTime;
		}
		else
		{
			Shoot();
			shootTimeLeft = shootTimer;
		}
	}
}
