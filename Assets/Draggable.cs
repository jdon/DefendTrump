using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject itemBeingDragged;

    Vector3 startPosition;
    Transform startParent;

    public string towerType = "Basic";

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Vector3 towerPos = transform.position;
        towerPos = Camera.main.ScreenToWorldPoint(towerPos);
        towerPos.z = 0;
        Debug.Log(towerPos.ToString());
        GameObject tower = Instantiate(Resources.Load("Tower"),towerPos, Quaternion.identity) as GameObject;
        transform.position = startPosition;
        FindEnemy settings = tower.GetComponent<FindEnemy>();
		starupshit startup = GameObject.FindGameObjectWithTag ("StartupScript").GetComponent<starupshit> ();
		if(startup.Money < settings.towerPrice)
		{
			//your poor son
			Destroy(tower);
			return;
		}
		startup.Money -= settings.towerPrice;
        switch (towerType)
        {
            case "AoE":
                settings.aoe = true;
                settings.fireDelay = 1f;
                settings.aoeRange = 5;
                settings.aoeDamage = 50;
                settings.towerRange = 10;
                settings.priortityHealth = true;
                break;
            case "Basic":
            default:
                settings.fireDelay = 0.5f;
                settings.towerRange = 20;
                settings.damage = 100;
                break;
        }

        
    }
}
