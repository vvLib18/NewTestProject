using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutine : MonoBehaviour {
	private Renderer m_renderer;
	// Use this for initialization
	void Start () {
		m_renderer = this.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			StartCoroutine(Fade());
		}
	}

	IEnumerator Fade() {
		for (float i = 100f; i > 0; i-=1f)
		{
			Vector3 oldPos = this.transform.position;
			Vector3 newPos = oldPos + new Vector3(1f, 0f, 0f);
			this.transform.position = newPos;
			Debug.Log("--->>");
			yield return null; 
		}
		
	}
}
