using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float maxLifeTime = 2.0f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, maxLifeTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log(collision.tag);
		if(collision.CompareTag("Enemy"))
		{
			collision.GetComponent<EnemyHealth>().subtractHealth();
			Destroy(gameObject);
		}
	}
}
