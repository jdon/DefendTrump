using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerOptionsPane : MonoBehaviour {

    public GameObject currentTower;
    private Dropdown priorityDropdown;
	// Use this for initialization
	void Start () {
        currentTower = null;
        priorityDropdown = GameObject.FindGameObjectWithTag("toggle").GetComponent<Dropdown>();
        priorityDropdown.interactable = false;
	}


    public void LoadTowerSettings()
    {
        FindEnemy enstats = currentTower.GetComponent<FindEnemy>();
        priorityDropdown.interactable = true;
        priorityDropdown.value = enstats.priority;
    }

    public void SetTowerPriority()
    {
        FindEnemy script = currentTower.GetComponent<FindEnemy>();
        script.priority = priorityDropdown.value;

    }

    public void priorityChanged()
    {
        FindEnemy script = currentTower.GetComponent<FindEnemy>();
        script.priority = priorityDropdown.value;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
