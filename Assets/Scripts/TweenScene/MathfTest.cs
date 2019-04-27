using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathfTest : MonoBehaviour {

	 float myStartValue = 0f;
	 float myEndValue = 90f;
	 float factor = 0f;
	 public RectTransform targetTransform;
	 float rotAngle = 0f;
	// // Use this for initialization
	// void Start () {
		
	// }
	
	// // Update is called once per frame
	 void Update () {
	 	// rotAngle = Mathf.Lerp(myStartValue, myEndValue, factor);
		
	 	// factor += Time.deltaTime;

	 	// Debug.Log(rotAngle);
	 	// targetTransform.Rotate(Vector3.forward, rotAngle, Space.World);
	 	// Debug.Log(targetTransform.eulerAngles);

	 	targetTransform.Translate(new Vector3(10f, 0f, 0f) * Time.deltaTime);

	 }
}
