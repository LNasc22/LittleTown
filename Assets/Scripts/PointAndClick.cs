using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClick : MonoBehaviour
{
    public Transform targetObj;
    Camera camera1;
    void Start()
    {
        camera1 = GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera1.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            targetObj.position = hit.point;
        }

    }
}
