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
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Road"){

			Debug.Log ("road");	
		}
	}
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localScale = new Vector3(2.06f, 2.06f, 1);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Vector3 towerPos = transform.position;
        towerPos = Camera.main.ScreenToWorldPoint(towerPos);
        towerPos.z = 0;
		//find roads and check if the tower can rekt scrubs or not
		GameObject[] Roads = GameObject.FindGameObjectsWithTag("Road");
        Debug.Log(towerPos.ToString());
        GameObject tower = Instantiate(Resources.Load("Tower"),towerPos, Quaternion.identity) as GameObject;
        transform.position = startPosition;
        transform.localScale = new Vector3(1,1, 1);
        FindEnemy settings = tower.GetComponent<FindEnemy>();
		starupshit startup = GameObject.FindGameObjectWithTag ("StartupScript").GetComponent<starupshit> ();
		if(startup.Money < settings.towerPrice)
		{
			//your poor son
			Destroy(tower);
			return;
		}
		startup.Money -= settings.towerPrice;
        SpriteRenderer towerSpriteRenderer = tower.GetComponent<SpriteRenderer>();
        starupshit spriteGetter = GameObject.FindGameObjectWithTag("StartupScript").GetComponent<starupshit>();
        switch (towerType)
        {
            case "Sniper":
                towerSpriteRenderer.sprite = spriteGetter.sniperR;
                settings.towerRange = 200f;
                settings.aoe = false;
                settings.damage = 120;
                settings.fireDelay = 1.5f;
                break;
            case "RapidFire":
                settings.towerRange = 50;
                settings.damage = 75;
                settings.fireDelay = 0.1f;
                towerSpriteRenderer.sprite = spriteGetter.rapidfireR;
                break;
            case "BigRocket":
                settings.aoe = true;
                settings.damage = 100;
                settings.fireDelay = 2f;
                settings.aoeRange = 6;
                settings.aoeDamage = 75;
                settings.towerRange = 50;
                towerSpriteRenderer.sprite = spriteGetter.bigrocketR;
                break;
            case "Rocket":
                settings.aoe = true;
                settings.damage = 50;
                settings.aoeDamage = 50;
                settings.fireDelay = 1f;
                settings.towerRange = 20f;
                towerSpriteRenderer.sprite = spriteGetter.rocketR;
                break;
            default:
                settings.fireDelay = 0.5f;
                settings.towerRange = 40;
                settings.damage = 25;
                settings.aoe = false;
                towerSpriteRenderer.sprite = spriteGetter.BasicR;
                break;
        }
        settings.priority = 0;

        
    }
}
