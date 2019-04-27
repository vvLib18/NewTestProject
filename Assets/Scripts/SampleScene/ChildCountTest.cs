using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCountTest : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GameObject go = new GameObject("top");
        Random.InitState(System.Environment.TickCount);
        for (int i = 0; i < Random.Range(3, 6); i++)
        {
            GameObject go2 = new GameObject("middle" + i.ToString());
            go2.transform.parent = go.transform;

            for (int j = 0; j < Random.Range(1, 8); j++)
            {
                GameObject go3 = new GameObject("bottom" + j.ToString());
                go3.transform.SetParent(go2.transform);
            }
        }

        Debug.Log(go.transform.childCount);
        GameObject middlego = GameObject.Find("middle" + Random.Range(0, go.transform.childCount));
        Debug.Log(middlego.transform.childCount);

    }

	// Update is called once per frame
	void Update () {
		
	}
}
