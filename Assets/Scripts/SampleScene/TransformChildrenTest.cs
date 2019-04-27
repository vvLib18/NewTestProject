using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformChildrenTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        System.Type ty = transform.GetType();
        Debug.Log(ty.ToString());
        Debug.Log(transform.childCount);
        foreach (Transform child in transform)
        {
            Debug.Log("before:" + child.position);
            child.position += Vector3.up * 10f;
            Debug.Log("after:" + child.position);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            foreach (Transform child in transform)
            {
                child.position += Vector3.up * 10f;
            }
        }
	}
}
