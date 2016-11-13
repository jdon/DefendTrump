using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starupshit : MonoBehaviour {

	public int enemyAmount = 10;
	public int spawnDelay = 0.1;

	private IEnumerator MyEvent()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnDelay); // wait half a second
			// do things
			spawnEnemy();
		}
	}

	public void spawnEnemy(){
		GameObject startPlace = GameObject.FindGameObjectWithTag("Start");
		GameObject enemy = Instantiate(Resources.Load("enemy"), startPlace.transform.position, Quaternion.identity)as GameObject;
	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i <= enemyAmount; i++) {
			StartCoroutine("MyEvent");
	}
	}
	// Update is called once per frame
	void Update () {
		//if(Input.GetMouseButton(0))
  //      {
  //          Debug.Log("keklick");
  //          Vector3 mouse = Input.mousePosition;
  //          mouse = Camera.main.ScreenToWorldPoint(mouse);
  //          mouse.z = 0;
  //          Debug.Log(mouse.x + " " + mouse.y + " " + mouse.z);
  //          GameObject tower = Instantiate(Resources.Load("Tower"),mouse,Quaternion.identity) as GameObject;

  //      }
	}

}
