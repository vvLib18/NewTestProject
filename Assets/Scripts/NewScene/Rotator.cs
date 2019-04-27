using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


public class Rotator : MonoBehaviour {
	#region  old 
	// public float speed;	// this is data

	// // Use this for initialization
	// void Start () {
		
	// }
	
	// // Update is called once per frame
	// void Update () {
	// 	transform.Rotate(0f, speed * Time.deltaTime, 0f); // this is behaviour
	// }

	#endregion


	public float speed;
}

// behavoiur

class RotatorSystem:ComponentSystem{

	struct Components{ // 这是我们要查找的特定的组件集合。（找到所有对象上符合这两个组件的对象）
		public Rotator rotator;
		public Transform transform;
	}

	// Note that when using update inside of a ComponentSystem we use the override and protected keywords.
	// run on the ComponentSystem every frame.
	protected override void OnUpdate(){
		float deltaTime = Time.deltaTime;
		// now search for all the objects that we want to rotate to do this we use the GetEntities()
		// iterate over all the entities using foreach loop
		 foreach (var e in GetEntities<Components>()){
			 e.transform.Rotate(0f, e.rotator.speed*deltaTime, 0f);
		 }
	}
}