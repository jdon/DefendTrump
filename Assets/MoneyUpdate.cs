using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyUpdate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.FindGameObjectWithTag("Gold Display").GetComponent<Text>().text = ("Current Gold : " + GameObject.FindGameObjectWithTag("StartupScript").GetComponent<starupshit>().Money);
	}
}
