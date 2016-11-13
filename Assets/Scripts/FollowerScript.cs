using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FollowerScript : MonoBehaviour {

    public GameObject[] waypoints;
    private int currentwaypoint = 0;
    public float speed = 3;
    public int x = 0;

	// Use this for initialization
	void Start () {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		Array.Sort(waypoints,delegate(GameObject Enemy1,GameObject Enemy2) {
			waypointCode enemy1Stats = Enemy1.GetComponent<waypointCode>();
			waypointCode enemy2Stats = Enemy2.GetComponent<waypointCode>();
			return enemy1Stats.num.CompareTo(enemy2Stats.num);
		});
	}

    void FixedUpdate()
    {
        //transform.position = GameObject.Find("Waypoint").transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Waypoint").transform.position, speed * Time.deltaTime);

        try
        {
            Vector3 target = waypoints[currentwaypoint].transform.position;
            transform.position = Vector3.MoveTowards(transform.position,target,speed * Time.deltaTime);
            if(transform.position == target)
            {
				if(waypoints.Length == (currentwaypoint+1))
				{
					//rip last waypoint
					EnemyStats enStats = GetComponent<EnemyStats>();
					GameObject startup = GameObject.FindGameObjectWithTag("StartupScript");
					starupshit GameStats = startup.GetComponent<starupshit>();
					GameStats.life -= enStats.lifeWorth;
					Destroy(this.gameObject);
					return;

				}
                currentwaypoint++;
            }
        }
        catch (Exception e) { }

    }


}
