using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelGridScale : MonoBehaviour {

    GridLayoutGroup gridLayoutGroup;
    RectTransform rect;
	// Use this for initialization
	void Start () {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        rect = GetComponent<RectTransform>();

        //gridLayoutGroup.cellSize = new Vector2(rect.rect.height, rect.rect.height);
        //rect.rect.Set(rect.rect.x,rect.rect.y,rect.rect.width,gridLayoutGroup.cellSize.y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
