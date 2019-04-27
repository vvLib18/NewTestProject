using UnityEngine;
using UnityEditor;

//[InitializeOnLoad] // 确保编辑器启动时被调用
public class Startup {

	static Startup() // 首先调用静态构造函数
    {
        Debug.Log("Up and running");
    }


}
