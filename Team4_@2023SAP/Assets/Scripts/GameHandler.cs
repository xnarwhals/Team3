using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public CameraFollow cameraFollow;
    private Vector3 cameraFollowPosition;
    private bool edgeScrolling = false;


    private void Start()
    {
        cameraFollow.Setup(() => cameraFollowPosition);


    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            edgeScrolling = !edgeScrolling;
        }

        float moveAmount = 15f;

        if (edgeScrolling)
        {
            float edgeSize = 30f;

            if (Input.mousePosition.x > Screen.width - edgeSize)
            {
                cameraFollowPosition.x += moveAmount * Time.deltaTime;//move right 
            }

            if (Input.mousePosition.x < edgeSize)
            {
                cameraFollowPosition.x -= moveAmount * Time.deltaTime;//move left 
            }

            if (Input.mousePosition.x > Screen.height - edgeSize)
            {
                cameraFollowPosition.x += moveAmount * Time.deltaTime;//move up 
            }

            if (Input.mousePosition.x < edgeSize)
            {
                cameraFollowPosition.x -= moveAmount * Time.deltaTime;//move down
            }

        }

    }
}