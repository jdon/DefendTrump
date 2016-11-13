using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour {

	public GameObject target;
	public float speed = 35;
	public float damage = 100;
	public bool aoe = false;
	public double aoeRange = 3;
	public float aoeDamage = 50;
	public int MaxAoeEnemyNum = 5;
    private Vector3 previousDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
		
	}

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

	void OnTriggerEnter2D(Collider2D other){
		Destroy (this.gameObject);
	}
	// Update is called once per frame
	void Update () {

        if(target == null)
        {
            if(previousDirection == Vector3.zero)
            {
                Destroy(this.gameObject);
            }
            transform.position = previousDirection + transform.position;
            return;
        }
        previousDirection = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime) - transform.position;
        transform.position = previousDirection + transform.position;
	}
}
