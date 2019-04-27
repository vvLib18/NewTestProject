using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionEulerAngles : MonoBehaviour {

    private Quaternion quaternion;  // 一个四元数
    private GameObject cube;        // 游戏对象Cube
    private float timeCount = 0.0f; // 时间计数


    private void Awake()
    {
        quaternion = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f); // 初始化一个四元数
        cube = CreateCube();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timeCount > 2.0f) {
            quaternion = Random.rotation;
            cube.transform.rotation = quaternion;

            timeCount = 0.0f;
        }

        timeCount = timeCount + Time.deltaTime;
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;

        Vector3 angles = quaternion.eulerAngles;
        GUI.Label(new Rect(10, 10, 0, 0), angles.ToString("F3"), style);

        GUI.Label(new Rect(10, 90, 250, 50), cube.transform.localEulerAngles.ToString("F3"), style);

    }

    private GameObject CreateCube() {
        GameObject newCube = new GameObject("Cube");

        GameObject minusZ = GameObject.CreatePrimitive(PrimitiveType.Quad);
        minusZ.transform.position = new Vector3(0.0f, 0.0f, -0.5f);
        minusZ.GetComponent<Renderer>().material.color = Color.gray;
        minusZ.transform.parent = newCube.transform;

        GameObject plusZ = GameObject.CreatePrimitive(PrimitiveType.Quad);
        plusZ.transform.position = new Vector3(0.0f, 0.0f, 0.5f);
        plusZ.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
        plusZ.GetComponent<Renderer>().material.color = Color.magenta;
        plusZ.transform.parent = newCube.transform;

        GameObject minusX = GameObject.CreatePrimitive(PrimitiveType.Quad);
        minusX.transform.position = new Vector3(-0.5f, 0.0f, 0.0f);
        minusX.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
        minusX.GetComponent<Renderer>().material.color = Color.yellow;
        minusX.transform.parent = newCube.transform;

        GameObject plusX = GameObject.CreatePrimitive(PrimitiveType.Quad);
        plusX.transform.position = new Vector3(0.5f, 0.0f, 0.0f);
        plusX.transform.Rotate(new Vector3(0.0f, 270.0f, 0.0f));
        plusX.GetComponent<Renderer>().material.color = Color.blue;
        plusX.transform.parent = newCube.transform;

        GameObject minusY = GameObject.CreatePrimitive(PrimitiveType.Quad);
        minusY.transform.position = new Vector3(0.0f, -0.5f, 0.0f);
        minusY.transform.Rotate(new Vector3(270.0f, 0.0f, 0.0f));
        minusY.GetComponent<Renderer>().material.color = Color.green;
        minusY.transform.parent = newCube.transform;

        GameObject plusY = GameObject.CreatePrimitive(PrimitiveType.Quad);
        plusY.transform.position = new Vector3(0.0f, 0.5f, 0.0f);
        plusY.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f));
        plusY.GetComponent<Renderer>().material.color = Color.red;
        plusY.transform.parent = newCube.transform;

        return newCube;
    }
}
