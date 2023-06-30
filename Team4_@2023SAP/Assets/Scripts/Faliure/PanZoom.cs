using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PanZoom : MonoBehaviour
{
    [SerializeField]
    private float panSpeed = 2f;
    [SerializeField]
    private float zoomSpeed = 3f;
    [SerializeField]
    private float zoomInMax = 40f;
    [SerializeField]
    private float zoomOutMax = 90f;

    private CinemachineInputProvider inputProvider;
    private CinemachineVirtualCamera virtualCamera;
    private Transform cameraTransfrom;


    private void Awake()
    {
        //get and set the input and camera 
        inputProvider = GetComponent<CinemachineInputProvider>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        cameraTransfrom = virtualCamera.VirtualCameraGameObject.transform;

    }

    private void Update()
    {
        //recieve the input of the axis as either +1 or -1 to know wheather to go +up/-down, -left/+right, +in/-out
        float x = inputProvider.GetAxisValue(0);
        float y = inputProvider.GetAxisValue(1);
        float z = inputProvider.GetAxisValue(2);

        if (x != 0 || y !=0)
        {
            PanScreen(x, y);
        }
        if (z != 0)
        {
            ZoomScreen(z); 
        }

       
    }

    
    public Vector2 PanDirection(float x, float y)
    {
        Vector2 direction = Vector2.zero;
        //y direction
        if (y >= Screen.height * .90f)
        {
            direction.y += 1;
        }
        else if (y <= Screen.height * .1f)
        {
            direction.y -= 1; 
        }
        //x direction
        if (x >= Screen.width * .90f)
        {
            direction.x += 1;
        }
        else if (y <= Screen.width * .1f)
        {
            direction.x -= 1;
        }
        return direction;

    }

    //take the x and y position of the mouse and pan camera towards that direction at panSpeed 
    public void PanScreen(float x, float y)
    {
        Vector2 direction = PanDirection(x, y);
        cameraTransfrom.position = Vector3.Lerp(cameraTransfrom.position, cameraTransfrom.position + (Vector3)direction, panSpeed * Time.deltaTime); 
    }

    //zoom functionality  
    public void ZoomScreen(float increment)
    { 
        float fov = virtualCamera.m_Lens.FieldOfView;
        float target = Mathf.Clamp(fov + increment, zoomInMax, zoomOutMax);
        virtualCamera.m_Lens.FieldOfView = Mathf.Clamp(fov, target, zoomSpeed * Time.deltaTime);          

    }
 

}
