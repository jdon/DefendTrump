using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	public double health = 100;


	// Use this for initialization
	void Start () {

	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Missile") {
			//Debug.Log ("kek-health");
			Destroy(this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}