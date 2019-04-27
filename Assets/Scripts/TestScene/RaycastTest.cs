using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    //private void FixedUpdate()
    //{
    //    Vector3 fwd = transform.TransformDirection(Vector3.forward);

    //    if (Physics.Raycast(transform.position, fwd, 10))
    //    {
    //        Debug.Log("射线撞击到了东西");
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, Vector3.forward, out hit))
    //    {
    //        Debug.Log("Found an object - distance: " + hit.distance);
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10f))
    //    {
    //        Debug.Log("Found an object - distance: " + hit.distance);
    //    }
    //}

    //private void Update()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    Debug.DrawRay(ray.origin, ray.direction * 100f, Color.yellow);
    //    if (Physics.Raycast(ray, 10)) {
    //        Debug.Log("Hit something !");
    //    }
    //}

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit, 10f)) {
            Debug.DrawLine(ray.origin, hit.point);
        }
    }

    //// Update is called once per frame
    //void Update () {
    //    int layerMask = 1 << 8; // LayerId为8
    //    layerMask = ~layerMask; // 非第8层

    //    RaycastHit hit;
    //    // 未射中第8层的物体，射中第8层以外的物体
    //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
    //    {
    //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    //        Debug.Log("Did Hit");
    //    } else { // 射线射中第8层的物体
    //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.white);
    //        Debug.Log("Did not Hit");
    //    }
    //}
}
