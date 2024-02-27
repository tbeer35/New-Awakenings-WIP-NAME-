using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to control the "clicker boxes"
public class clicker : MonoBehaviour
{
    //Set variables
    private Rigidbody targetRb;
    private GameManager gameManager;
    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>(); //get the rigid body of the box
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find the game manager
    }

    //Called every time the player clicks on a clicker box
    private void OnMouseDown() {
        if(gameManager.isGameActive){ //if the game is on
            Debug.Log("clicked the: " + gameObject.name); //debug log
            gameManager.OpenMenu(gameObject.tag); //Open the clicking menu based on the box's tag, ore mining menu for the ore box and chip collecting menu for the chip box
        }
    }
}
