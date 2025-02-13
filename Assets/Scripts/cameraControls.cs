using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to allow the player to move the camera
public class cameraControls : MonoBehaviour
{
    public Transform cameraTransform;
    //set variables
    public float normalSpeed;
    public float fastSpeed;
    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    //public Vector3 zoomAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;
    //public Vector3 newZoom;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;

    void Start() {
        //set positions and rotations
        newPosition = transform.position;
        newRotation = transform.rotation;
        //newZoom = cameraTransform.localPosition;
    }

    void Update() {
        HandleMovementInput(); //call the handle method
        //HandleMouseInput();
    }

    /*void HandleMouseInput(){
        if(Input.GetMouseButtonDown(0)){ //dont use ray casts
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if(plane.Raycast(ray, out entry)){
                dragStartPosition = ray.GetPoint(entry);
            }
        }
        if(Input.GetMouseButton(0)){
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if(plane.Raycast(ray, out entry)){
                dragCurrentPosition = ray.GetPoint(entry);

                newPosition = transform.position + dragStartPosition - dragCurrentPosition;
            }
        }
    }
    */

    //Method to process player input and apply it to the camera
    void HandleMovementInput() {
        if(Input.GetKey(KeyCode.LeftShift)){ //if they press leftshift increase the speed
            movementSpeed = fastSpeed;
        } else {
            movementSpeed = normalSpeed;
        }
        movementSpeed *= Time.deltaTime;
        //take in input from keyboard and apply speed in a direction based on the key pressed
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            newPosition += (transform.forward * movementSpeed); //up
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            newPosition += (transform.forward * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            newPosition += (transform.right * movementSpeed);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            newPosition += (transform.right * -movementSpeed);
        }

        //take in input from keyboard for rotation
        if(Input.GetKey(KeyCode.Q)){ //Q rotates left
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if(Input.GetKey(KeyCode.E)){ //E rotates right
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }
        
        
        
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime *movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime *movementTime);
       // cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }

}
