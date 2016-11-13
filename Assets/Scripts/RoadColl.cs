using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadColl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Tower"){
			starupshit startup = GameObject.FindGameObjectWithTag ("StartupScript").GetComponent<starupshit> ();
			FindEnemy settings = other.gameObject.GetComponent<FindEnemy>();
			if (startup.Money < settings.towerPrice) {
				//your poor son
				Destroy (other.gameObject);
				return;
			} else {
			//refund the money as they actually bought the tower
				startup.Money += settings.towerPrice;
			}
			Destroy (other.gameObject);
			//Debug.Log ("topkekkekekekek");	
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
