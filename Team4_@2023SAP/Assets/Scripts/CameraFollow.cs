using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    private Func<Vector3> GetCameraFollowPositionFunc;

    public void Setup(Func<Vector3> GetCameraFollowPositionFunc) //The Initial setup target for the camera 
    {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }

    public void SetGetCameraFollowPositionFunc(Func<Vector3> GetCameraFollowPositionFunc) //only if we want to change what the camera is looking at 
    {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }

    private void Update()
    {
        Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();//new vector 3 is equal to the function parameter?
        cameraFollowPosition.z = transform.position.z; //Only x and y 

        //creating and assigning camera variables
        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition, transform.position);
        float cameraMoveSpeed = 2f;


        //logic for moving 
        if (distance > 0)
        {
            Vector3 newCameraPosition = transform.position = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
            
            float distanceAfterMoving = Vector3.Distance(newCameraPosition,cameraFollowPosition);

            if (distanceAfterMoving > distance)
            {
                //Target Overshoot
                newCameraPosition = newCameraPosition; //Camera does not freak out and stays at current position 
            }

            transform.position = newCameraPosition; //move the camera 
        } 
    }

}
   