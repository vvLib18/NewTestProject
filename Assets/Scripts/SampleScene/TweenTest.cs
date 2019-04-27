using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTest : MonoBehaviour {

	Transform trans;
	Vector3 previousScale;

	public AnimationCurve curve;
	[Range(0.1f,1f)]
	public float durationTime = 1;
	float x;
	// Use this for initialization
	void Start () {
		previousScale = this.transform.localScale;
		trans = this.GetComponent<RectTransform>();
		// 修改其scale值
		this.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		x = Time.deltaTime*5 / durationTime;
		trans.localScale = Vector3.Lerp(this.transform.localScale, previousScale, curve.Evaluate(x));
	}
}
