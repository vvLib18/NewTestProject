using UnityEditor;
using UnityEngine;

//[InitializeOnLoad]
public class MyClass {

	static MyClass()
    {
        //EditorApplication.update += Update;
    }

    static void Update()
    {
        Debug.Log("Updating");
    }

}
