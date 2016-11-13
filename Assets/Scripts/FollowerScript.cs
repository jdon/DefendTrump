using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour {

    public GameObject[] waypoints;
    private int currentwaypoint = 0;
    public float speed = 3;

	// Use this for initialization
	void Start () {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
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

				}
                currentwaypoint++;
            }
        }
        catch (Exception e) { }

    }


}
