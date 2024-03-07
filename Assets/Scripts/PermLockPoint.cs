using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script attached to the permanent lock points on already built rooms, deletes and removes walls and lockpoints as needed
public class PermLockPoint : MonoBehaviour
{
    //create variables
    private bool parentOff;
    public GameObject ParentWall;
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
            if(transform.forward == other.transform.forward){ //if they're both facing the same way
                ParentWall.gameObject.SetActive(false); //turn off the wall attached to this lockpoint
                //TODO: find others parent and also delete it assuming its a wall, then insantiate the small gate A prefab
                Debug.Log("other's parent is");
                Debug.Log(other.transform.parent.gameObject);
                Debug.Log("that was other's parent");
                parentOff = true;
            }else if(other.tag.Equals("permLockPoint")){ //if its  colliding with another permanent lock point implying a room has just been placed
                //ParentWall.gameObject.SetActive(false);
                Destroy(gameObject); //destroy itself
                Destroy(other.gameObject); //destroy what collided with it
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
