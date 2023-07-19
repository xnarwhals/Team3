using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScan : MonoBehaviour
{
    PaintExample Player;
    public float Range;

    void Update()
    {
        Vector3 direction = Vector3.forward;
        Ray ray = new Ray(transform.position, transform.TransformDirection(-direction * Range));
        Debug.DrawRay(transform.position, transform.TransformDirection(-direction * Range));

        if (Physics.Raycast(ray, out RaycastHit hit, Range))
        {
            if (hit.collider.tag == "MainCamera")
            {
                Debug.Log("Hamburger");
            }
                  
        }
    }
}
