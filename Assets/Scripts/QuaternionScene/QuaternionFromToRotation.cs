using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionFromToRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.forward);
	}
}
