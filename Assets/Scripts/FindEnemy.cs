using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class FindEnemy : MonoBehaviour {

	public double towerRange = 20;
	public float towerPrice = 100;
	GameObject bullet;
    public float fireDelay = 0.1f;
	public int priority = 0;
	public Boolean priortityHealth = false;
	public Boolean priortityLast = false;
	public float speed = 35;
	public float damage = 100;
	public bool aoe = false;
	public double aoeRange = 3;
	public float aoeDamage = 50;
	int colorint = 0;
	// Use this for initialization
	void Start () {
        StartCoroutine("MyEvent");
	}

    private IEnumerator MyEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireDelay); // wait half a second
                                                   // do things
            tryFire();
			Debug.Log ("colour:" + colorint);
        }
    }

    void tryFire()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("enemy");
		//sort
		if(priortityHealth == true){
			Array.Sort(Enemies,delegate(GameObject Enemy1,GameObject Enemy2) {
				EnemyStats enemy1Stats = Enemy1.GetComponent<EnemyStats>();
				EnemyStats enemy2Stats = Enemy2.GetComponent<EnemyStats>();
				return enemy1Stats.health.CompareTo(enemy2Stats.health);
			});
		}
		if(priortityLast == true)
		{
			GameObject[] En = GameObject.FindGameObjectsWithTag("enemy");;
			int x = 0;
			for (int i = Enemies.Length-1; i > 0; i--) {
				En [x] = Enemies [i];
				x++;
			}
			Enemies = En;
		}
		foreach (GameObject e in Enemies)
        {
            //bool enemyAlive = true;
            EnemyStats stat = e.GetComponent<EnemyStats>();
            //double enemyHealth = stat.health;
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist <= towerRange)
            {
                GameObject test = Instantiate(Resources.Load("Missile"), transform.position, Quaternion.identity) as GameObject;
				HitEnemy scri = test.GetComponent<HitEnemy>();
				SpriteRenderer re = test.GetComponent<SpriteRenderer>();
				//Debug.Log (re.color);
				if (colorint == 0){
					re.color = Color.green;
				}
				if (colorint == 1){
					re.color = Color.red;
				}
				if (colorint >= 2){
					re.color = Color.blue;
					colorint = -1;
				}
                scri.target = e;
				scri.aoe = aoe;
				scri.aoeRange = aoeRange;
				scri.aoeDamage = aoeDamage;
				scri.damage = damage;
				scri.speed = speed;
				colorint++;
                return;
            }
        }
    }


    void OnMouseDown()
    {
        Debug.Log("click LUL:");
        TowerOptionsPane pane = GameObject.FindGameObjectWithTag("OptionsMenu").GetComponent<TowerOptionsPane>();
        pane.currentTower = this.gameObject;
        pane.LoadTowerSettings();
    }
}
