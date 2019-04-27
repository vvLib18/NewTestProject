using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWayPoint : MonoBehaviour {
	float speed = 1f;
	public Transform [] waypoints;
	// Use this for initialization
	void Start () {
		waypoints = new Transform[transform.childCount];
		int i = 0;

		foreach (Transform t in transform)
		{
			waypoints[i++] = t;
		}

		Debug.Log("输出 Fixed Timestep: " + Time.fixedDeltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Time.deltaTime * speed * Input.GetAxis("Horizontal");
		this.transform.Translate(Vector3.right * distance, Space.Self);
	}
}
