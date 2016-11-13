using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	public double health = 100;
	public float lifeWorth = 1;
	public float reward = 10;


	void OnDestroy() {
		GameObject Gamestartup = GameObject.FindGameObjectWithTag ("StartupScript");
		if (Gamestartup == null){
			return;	
		}
		starupshit GameStats = Gamestartup.GetComponent<starupshit> ();
		GameStats.Money += reward;
		print("enemy was destroyed");
	}
	// Use this for initialization
	void Start () {

	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Missile") {
			//Debug.Log ("kek-health");
			HitEnemy script = other.gameObject.GetComponent<HitEnemy>();
			if (script.aoe == true) {
				//its an aoe bomb
				GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
				int enemynum = 0;
				foreach (GameObject e in enemies) {
					float dist = Vector3.Distance(transform.position, e.transform.position);
					if (dist <= script.aoeRange) {
						enemynum++;
						if(enemynum <= script.MaxAoeEnemyNum){
							EnemyStats enstats = e.GetComponent<EnemyStats> ();
							enstats.health -= script.aoeDamage;
							if (enstats.health <= 0) {
								Destroy (e.gameObject);
							}	
						}
					}
				}
			}
			health -= script.damage;
			if (health <= 0) 
			{
				Destroy(this.gameObject);	
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
