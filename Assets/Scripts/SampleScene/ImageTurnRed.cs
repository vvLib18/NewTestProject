using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTurnRed : MonoBehaviour {
    Image image;
	// Use this for initialization
	void Start () {
        image = this.transform.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnRed()
    {
        image.color = new Color(1f, 0f, 1f, .5f);
    }

    public void TurnWhite()
    {
        image.color = new Color(1f, 1f, 1f, 1f);
    }
}
