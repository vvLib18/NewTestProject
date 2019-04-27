using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MissionCardTween : MonoBehaviour {
	public RectTransform missionCardTransform;
	private bool isIn = false;	// 是否弹出

	// Use this for initialization
	void Start () {
		Tweener tweener = missionCardTransform.DOLocalMove(new Vector3(0f, 0f, 0f), 0.3f).SetId("missionCardTween");
		tweener.SetAutoKill(false);
		// tweener.Pause();
		DOTween.Pause("missionCardTween");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			OnClick();
		}
	}

	void OnClick(){
		if (!isIn) {
			missionCardTransform.DOPlayForward();		// 前进
			isIn = true;
		} else {
			missionCardTransform.DOPlayBackwards();		// 后退
			isIn = false;
		}
	}
}
