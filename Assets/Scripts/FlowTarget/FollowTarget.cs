using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public Transform target;	// 游戏对象
	public Vector3 offset = Vector3.zero;	// 偏移量
	public RectTransform rectTransform; 	// UI

	public Camera m_Camera;

	private Vector3 vec;
	// Use this for initialization
	void Start () {
		//rectTransform = GetComponent<RectTransform>();
		vec = target.position - m_Camera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null || rectTransform == null)
		{
			return;
		}
		// 从世界空间到屏幕空间的转换
		Vector3 targetScreenPosition = Camera.main.WorldToScreenPoint(target.position);
		
		rectTransform.position = targetScreenPosition;
		
	}

	void LateUpdate() {
		
		StartCoroutine(LateMinute());
	}

	IEnumerator LateMinute()
	{
		yield return new WaitForSeconds(2f);
		m_Camera.transform.position = Vector3.Lerp(m_Camera.transform.position, target.position + vec, 2f) ;
		m_Camera.transform.LookAt(target);
	}
}
