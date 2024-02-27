using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to control camera zoom
public class cameraZoom : MonoBehaviour
{
    //set variables
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
            zoomCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed; //when you scroll in the camera zooms in and vice versa
        }
    }
}
