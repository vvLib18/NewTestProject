using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollCardsTest : MonoBehaviour , IBeginDragHandler, IEndDragHandler{

    //public ScrollRect scrollRect;

	// Use this for initialization
	void Start () {

	}

    //public void OnDrag(PointerEventData data)
    //{
    //    Debug.Log("Currently dragging " + this.name);
    //    Debug.Log("data" + data);
    //}

    // Update is called once per frame
    void Update () {

    }

    //void IDragHandler.OnDrag(PointerEventData eventData)
    //{
    //    throw new System.NotImplementedException();
    //}

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin : " + eventData.position);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End : " + eventData.position);
    }

    //public void OnValueChange(Vector2 vec2)
    //{
    ////Debug.Log(vec2);
    //    //Debug.Log("Velocity: " + scrollRect.velocity);
    //    Debug.Log("normalizedPos: " + scrollRect.normalizedPosition);

    //}
}
