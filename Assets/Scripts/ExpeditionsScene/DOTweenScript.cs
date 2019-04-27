using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DOTweenScript : MonoBehaviour {

	// Use this for initialization
	// float myValue = -10f;
	public GameObject enemy;
	void Start () {
		// transform.DOMoveX(10f, 2f);
		// // transform.DOMoveX(10f, 2f).From();
		// transform.DOMoveX(10f, 2f).From(true);

		// Sequence mySequence = DOTween.Sequence();	// 创建一个序列
		// mySequence.Append(transform.DOMoveX(10f, 2f));	// 
		// mySequence.Join(transform.DORotate(new Vector3(0f, 180f, 0f), 1f));	//
		// mySequence.AppendCallback(MyCallback);
		// mySequence.PrependInterval(1f);
		// mySequence.Insert(0, transform.DOScale(new Vector3(3, 3, 3), mySequence.Duration()));

		// Sequence mySequence = DOTween.Sequence();
		// mySequence.Append(transform.DOMoveX(10f, 2.5f))
		// 	.Join(transform.DORotate(new Vector3(0f, 270, 0f), 2.5f))
		// 	.PrependInterval(1)
		// 	.Insert(0, transform.DOScale(new Vector3(3, 3, 3), mySequence.Duration()));
		
		// Debug.Log("DOTween.To()--->> ");
		// DOTween.To(()=>myValue, x=>myValue=x, 100f, 5f);	// 10 ->>> 100
		
		// Debug.Log("DOTween.To().From()--->> ");
		// DOTween.To(()=>myValue, x=>myValue=x, 100f, 5f).From(); // 100 ->>> 10
		
		// Debug.Log("DOTween.To().From(true)--->> ");
		// DOTween.To(()=>myValue, x=>myValue=x, 100f, 5f).From(true); // 110 ->>> 10

		for (int i = 10; i > 0; --i) {
			GameObject newGo = Instantiate(enemy);
			newGo.name = "Enemy_" + i;
			newGo.transform.SetParent(transform);
			// StartCoroutine(WaitCoroutine());
		}
	}
	
	// Update is called once per frame
	void Update () {
		// if (Input.GetKeyDown(KeyCode.A)) {
		// 	// transform.DOMoveX(10f, 2f);
		// 	DOTween.To(()=>myValue, x=>myValue=x,100f,3f);
		// }
		// if (Input.GetKeyDown(KeyCode.S)){
		// 	transform.DOMoveX(0, 2f).From();
		// }
		// // Debug.Log(myValue);

		// if (Input.GetKeyDown(KeyCode.D)) {
		// 	StartCoroutine(SomeCoroutine());
			
		// }

		// if (Input.GetKeyDown(KeyCode.W)) {
		// 	Tween myTween = transform.DOMoveX(10f, 1f);
		// 	Vector3 myPathMidPoint = myTween.PathGetPoint(1f);
		// 	Debug.Log(myPathMidPoint);
		// }
	}

	private void MyCallback() {
		Debug.Log("this is MyCallback !");
	}

	IEnumerator SomeCoroutine() {

		// WaitForCompletion()
		// Tween myTween = transform.DOMoveX(10f, 1);
		// yield return myTween.WaitForCompletion();
		// // This log will happen after the tween has completed
		// Debug.Log("Tween completed!");

		// WaitForElaspedLoops(int elaspedLoops)
		// Tween myTween = transform.DOMoveX(10f, 1).SetLoops(4);
		// yield return myTween.WaitForElapsedLoops(2);
		// // This log will happen after the 2nd loop has finished
		// Debug.Log("Tween has looped twice !");

		// WaitForKill()
		// Tween myTween = transform.DOMoveX(10f, 1f);
		// yield return myTween.WaitForKill();
		// // This log will happen after the tween has been killed
		// Debug.Log("Tween Killed !");

		// WaitForPosition(float position)
		// Tween myTween = transform.DOMoveX(10f, 1f);
		// yield return myTween.WaitForPosition(0.3f);
		// // This log will happen after the tween has played for 0.3 seconds
		// Debug.Log("Tween has played for 0.3 seconds !");

		// WaitForStart()
		Tween myTween = transform.DOMoveX(10f, 1f);
		yield return myTween.WaitForStart();
		// This log will happen when the tween starts
		Debug.Log("Tween started! ");

	}

	IEnumerator WaitCoroutine() {
		yield return new WaitForEndOfFrame();
	}
}
