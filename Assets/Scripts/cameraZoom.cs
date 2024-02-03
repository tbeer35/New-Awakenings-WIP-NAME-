using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour
{
    public float ScrollSpeed = 10;
    public Camera zoomCamera;

    // Start is called before the first frame update
    void Start() 
    {
        //Changing the camera's size to zoom in and out
        zoomCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        HandleZoomInput();
    }

    void HandleZoomInput(){
        if(zoomCamera.orthographic){
            zoomCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
    }
}
