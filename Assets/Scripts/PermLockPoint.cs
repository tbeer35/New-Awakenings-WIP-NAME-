using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script attached to the permanent lock points on already built rooms, deletes and removes walls and lockpoints as needed
public class PermLockPoint : MonoBehaviour
{
    //create variables
    private bool parentOff;
    public GameObject ParentWall;
    public GameObject door;
    public GameObject newWall;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find the game manager
        parentOff = false;
        gameManager.AddToList(gameObject); //call the gameManagers AddToList method to make sure it knows about all lock points in the game
    }

    //Method called when the lockpoint collides with another object, deletes objects as needed
    private void OnTriggerEnter(Collider other) 
    {
        if(other != ParentWall){ //if it isn't the wall attached to the lockpoint
            if(transform.forward == other.transform.forward && !other.CompareTag("permLockPoint")){ //if they're both facing the same way
                ParentWall.gameObject.SetActive(false); //turn off the wall attached to this lockpoint
                //TODO: find others parent and also delete it assuming its a wall, then insantiate the small gate A prefab where the new wall was
                parentOff = true;
            }else if(other.tag.Equals("permLockPoint")){ //if its  colliding with another permanent lock point implying a room has just been placed
                newWall = other.transform.parent.gameObject;
                Instantiate(door, ParentWall.transform.position, ParentWall.transform.rotation);//THIS WORKS BUT THERES 2 EACH PERMLOCKPOINT CALLS 
                Destroy(ParentWall);
                Destroy(other.gameObject); //destroy what collided with it
                Destroy(gameObject); //destroy itself
            }
        }
    }

    //Method called when the other lockpoint stops colliding with this one
    private void OnTriggerExit(Collider other) 
    {
        if(parentOff == true){ //if the parent wall was turned off
            ParentWall.gameObject.SetActive(true); //turn the parent wall back on
            parentOff = false;
        }
    }
}
