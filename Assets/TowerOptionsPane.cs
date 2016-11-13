using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerOptionsPane : MonoBehaviour {

    public GameObject currentTower;
    static Toggle priorityLastToggle;
    static Toggle priorityHealthToggle;
	// Use this for initialization
	void Start () {
        currentTower = null;
        priorityLastToggle = GameObject.Find("PriorityLastToggle").GetComponent<Toggle>();
        priorityHealthToggle = GameObject.Find("PriorityHealthToggle").GetComponent<Toggle>();
	}


    public void LoadTowerSettings()
    {
        FindEnemy enstats = currentTower.GetComponent<FindEnemy>();
        priorityLastToggle.isOn = enstats.priortityLast;
        priorityHealthToggle.isOn = enstats.priortityHealth;
    }

    public void SetTowerSettings()
    {
        FindEnemy script = currentTower.GetComponent<FindEnemy>();

        script.priortityLast = priorityLastToggle.isOn;
        script.priortityHealth = priorityHealthToggle.isOn;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
