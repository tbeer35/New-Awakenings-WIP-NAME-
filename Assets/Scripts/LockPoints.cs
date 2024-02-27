using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to lock the blueprint room into valid building spaces and allow player to unlock it
public class LockPoints : MonoBehaviour
{
    //Create variables
    public GameObject Blueprint;
    private Vector3 distance;
    private Vector3 newPos;
    private Transform greenBall;

    // Start is called before the first frame update
    void Start()
    {
        //BlueprintRooms.instance.unlocked = false;
        BlueprintRooms.instance.ChangeColor("red"); //Set the blueprint room's color to red on start (it starts white)
    }

    // Update is called once per frame, if the blueprint room is locked check to see if it should be unlocked
    void Update()
    {
        if(BlueprintRooms.instance.unlocked == false){
            float mouseVal = (Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y"))/2; //get the mouse's speed
            if(mouseVal >= 0.3){ //if the speed if greater than 0.3 free the blueprint and unlock it
                Debug.Log("greenball is equal to: " + greenBall); //debug statement
                //greenBall.gameObject.SetActive(true);
                BlueprintRooms.instance.unlocked = true; //Unlock the room
                BlueprintRooms.instance.ChangeColor("red"); //Change it to red, no longer in a valid build spot
            }
        }

    }

    //Method called when the Green Ball "Lockpoints" on a blueprint room and an established room touch each other
    private void OnTriggerEnter(Collider other) //take in the collider of the other green ball
    {
        if(transform.forward == other.transform.forward){ //if they're both facing the same correct way
            greenBall = other.transform; //set the transforms equal to each other
            Debug.Log(other.transform); //debug statement
            distance = transform.position - other.transform.position; //figure out the distance between the 2 green balls
            newPos = Blueprint.transform.position - distance; //subtract the distance from the current position to find the new position
            Blueprint.transform.position = newPos; //set the new position
            BlueprintRooms.instance.unlocked = false; //lock the blueprint room
            BlueprintRooms.instance.ChangeColor("green"); //change the color of the blueprint room to green, this is a valid building spot
            //greenBall.gameObject.SetActive(false);
        }
    }
    
}
