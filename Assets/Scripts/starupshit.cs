using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starupshit : MonoBehaviour {

	public int enemyAmount = 10;
	public float spawnDelay = 0.5f;
	public float Money = 150;
	public float life = 100;
	private float multiplier = 0.9f;

    public Sprite BasicR;
    public Sprite BasicG;
    public Sprite BasicB;

    public Sprite rocketR;
    public Sprite rocketG;
    public Sprite rocketB;

    public Sprite bigrocketR;
    public Sprite bigrocketG;
    public Sprite bigrocketB;

    public Sprite rapidfireR;
    public Sprite rapidfireG;
    public Sprite rapidfireB;

    public Sprite sniperR;
    public Sprite sniperG;
    public Sprite sniperB;

    public bool run = false;
    private IEnumerator MyEvent()
	{

        for (int i = 0; i < enemyAmount; i++)
        {
            Debug.Log("spawning");
            Debug.Log(enemyAmount + " i:" + i);
            yield return new WaitForSeconds(spawnDelay); // wait to
                                                         // do things
            spawnEnemy();
        }
    }

	public void spawnEnemy(){
		GameObject startPlace = GameObject.FindGameObjectWithTag("Start");
		GameObject enemy = Instantiate(Resources.Load("enemy"), startPlace.transform.position, Quaternion.identity)as GameObject;
		EnemyStats enStats = enemy.GetComponent<EnemyStats> ();
		FollowerScript followerstats = enemy.GetComponent<FollowerScript> ();
        enStats.health *= multiplier;
        followerstats.speed *= multiplier;
		//enemyAmount *= (int)multiplier;
	}

    // Use this for initialization
    void Start()
    {
        StartCoroutine("MyEvent");
    }
	// Update is called once per frame
	void Update () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("enemy");
	}

}
