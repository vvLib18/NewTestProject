using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionLookRotation : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 relativePos = target.position - transform.position;// 方向为：游戏对象指向目标物体

        // forward : relativePos
        // upwards : Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        // 设置rotation属性至目标角度
        transform.rotation = rotation;
	}
}
