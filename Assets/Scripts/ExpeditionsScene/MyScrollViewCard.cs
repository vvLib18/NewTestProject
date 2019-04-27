using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyScrollViewCard : MonoBehaviour {
	private Vector2 touchFirst = Vector2.zero;
	private Vector2 touchSecond = Vector2.zero;
	private Vector2 offset;
	public RectTransform mScrollCardsPanel;
	
	private float mScrollCardsPanelPosY;
	private float mScrollCardsPanelPosZ;

	private Vector2 mScrollCardsPaneloffsetMax;
	private Vector2 mScrollCardsPaneloffsetMin;

	public RectTransform imageLeft3;


	public RectTransform image1;
	public RectTransform image2;

	private bool isNewImage = false;
	private void Start() {
		mScrollCardsPanelPosY = mScrollCardsPanel.position.y;
		mScrollCardsPanelPosZ = mScrollCardsPanel.position.z;
		mScrollCardsPaneloffsetMax = mScrollCardsPanel.offsetMax;
		mScrollCardsPaneloffsetMin = mScrollCardsPanel.offsetMin;

		Debug.Log("SizeDelta: " + mScrollCardsPanel.position);
		Debug.Log("offsetMax: " + mScrollCardsPanel.offsetMax);
		Debug.Log("offsetMin: " + mScrollCardsPanel.offsetMin);
		Debug.Log("rect : " + mScrollCardsPanel.rect);
	}

	private void OnGUI() {
		if(Event.current.type == EventType.MouseDown) { // 按下
			touchFirst = Event.current.mousePosition; // 按下时的位置
			Debug.Log(Event.current.mousePosition); // 480-1540
		}
		if(Event.current.type == EventType.MouseDrag) { // 按下
			touchSecond = Event.current.mousePosition; // 按下时的位置
			if (touchSecond.x < touchFirst.x ) { // 左滑
				// offset = touchFirst - touchSecond;
				Debug.Log("---->> Left : " + offset); // 正的
				// mScrollCardsPanel.position += new Vector3(-offset.x, mScrollCardsPanelPosY, mScrollCardsPanelPosZ);
				if (!isNewImage){
					Image newImage = Instantiate<Image>(Resources.Load<Image>("Image"));
					newImage.transform.SetParent(mScrollCardsPanel,false);
					isNewImage = true;
				}
			}
			if (touchSecond.x > touchFirst.x) { // 右滑
				// offset = touchFirst - touchSecond;
				Debug.Log("---->> Right : " + offset); // 负的
				// mScrollCardsPanel.position += new Vector3(-offset.x, mScrollCardsPanelPosY, mScrollCardsPanelPosZ);
				if (!isNewImage){
					Image newImage = Instantiate<Image>(Resources.Load<Image>("Image"));
					newImage.transform.SetParent(mScrollCardsPanel,false);
					isNewImage = true;
				}
			}
			// 固定大小
			mScrollCardsPanel.position += new Vector3(-offset.x, mScrollCardsPanelPosY, mScrollCardsPanelPosZ);
			mScrollCardsPanel.offsetMax = new Vector2(mScrollCardsPanel.offsetMax.x, mScrollCardsPaneloffsetMax.y);
			mScrollCardsPanel.offsetMin = new Vector2(mScrollCardsPanel.offsetMin.x, mScrollCardsPaneloffsetMin.y);

			touchFirst = touchSecond;
		}

		
	}


	// private void OnTriggerEnter2D(Collider2D other) {
	// 	Debug.Log("相交啦！！！！" + other.name);
	// }
	private void Update() {
		// if (IsRectTransformOverlap(mScrollCardsPanel, imageLeft3))
		// {
		// 	Debug.Log("相交了！！！");
		// } 
		Debug.Log(mScrollCardsPanel.position.x);

		if (mScrollCardsPanel.position.x < 540)
		{
			Debug.Log("Stop !!!!!!");
			mScrollCardsPanel.position = new Vector3(540f, mScrollCardsPanelPosY, mScrollCardsPanelPosZ);
			if (!isNewImage){
				Image newImage = Instantiate<Image>(Resources.Load<Image>("Image"));
				newImage.transform.SetParent(mScrollCardsPanel,false);
				isNewImage = true;
			}
		}
		if (mScrollCardsPanel.position.x > 1486)
		{
			Debug.Log("Stop !!!!!!");
			mScrollCardsPanel.position = new Vector3(1486f, mScrollCardsPanelPosY, mScrollCardsPanelPosZ);
			if (!isNewImage){
				
			}
		}
	}

	 public static bool IsRectTransformOverlap(RectTransform rect1, RectTransform rect2)
    {
        float rect1MinX = rect1.position.x - rect1.rect.width / 2;
        float rect1MaxX = rect1.position.x + rect1.rect.width / 2;
        float rect1MinY = rect1.position.y - rect1.rect.height / 2;
        float rect1MaxY = rect1.position.y + rect1.rect.height / 2;

        float rect2MinX = rect2.position.x - rect2.rect.width / 2;
        float rect2MaxX = rect2.position.x + rect2.rect.width / 2;
        float rect2MinY = rect2.position.y - rect2.rect.height / 2;
        float rect2MaxY = rect2.position.y + rect2.rect.height / 2;

        bool xNotOverlap = rect1MaxX <= rect2MinX || rect2MaxX <= rect1MinX;
        bool yNotOverlap = rect1MaxY <= rect2MinY || rect2MaxY <= rect1MinY;

        bool notOverlap = xNotOverlap || yNotOverlap;

        return !notOverlap;
    }
	
}
