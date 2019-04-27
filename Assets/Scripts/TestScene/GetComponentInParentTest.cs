using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetComponentInParentTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
       HingeJoint m_hingeJoint = GetComponentInParent<HingeJoint>();
        if (m_hingeJoint!=null)
        {
            m_hingeJoint.useSpring = false;
            Debug.Log(m_hingeJoint.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
