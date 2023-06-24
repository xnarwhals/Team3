using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;
    }

    //[SerializeField] private Camera cursor;

    //private void Update()
    //{
    //    cursor.ScreenToWorldPoint(Input.mousePosition);
    //    Vector3 mouseWorldPosition = cursor.ScreenToWorldPoint(Input.mousePosition);
    //    mouseWorldPosition.z = 0f;
    //    transform.position = mouseWorldPosition;
    //}

}
