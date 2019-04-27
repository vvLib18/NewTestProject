using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateUIByPrefab : MonoBehaviour {

    Button buttonPrefab = null;
    Button buttonOriginal = null;

	// Use this for initialization
	void Start () {
        RectTransform parent = GameObject.Find("Canvas").GetComponent<RectTransform>();
        buttonOriginal = Resources.Load<Button>("M_Button");
        buttonPrefab = Instantiate<Button>(buttonOriginal);
        buttonPrefab.transform.SetParent(parent, false);
        if (buttonPrefab != null) {
            Debug.Log("实例化成功！！！");
            Debug.Log(Screen.safeArea);
            Debug.Log(Screen.currentResolution);
            Resolution[] resolution = Screen.resolutions;
            Debug.Log("------->>");
            Debug.Log(resolution[1].refreshRate);
            Debug.Log(resolution[1].width);
            Debug.Log(resolution[1].height);
            Debug.Log(resolution[1].ToString());
            Debug.Log("<<-------");
            foreach (var item in resolution)
            {
                Debug.Log("resolution: " + item);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
