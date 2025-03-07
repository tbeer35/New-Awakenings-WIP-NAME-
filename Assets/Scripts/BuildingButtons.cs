using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Simple script to assign a listener to the buttons used for building rooms
public class BuildingButtons : MonoBehaviour
{
    //set variables
    private Button button;
    private GameManager gameManager;

    public int roomNum; //each room has a distinct number
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); //find the button
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find the game manager
        button.onClick.AddListener(() => MakeRoom(gameManager.isBlueprintActive)); //create the listener, this time it takes in a boolean
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //on click call the gameManager's build room function passing which room number the button corresponds too
    void MakeRoom(bool isBlueprintActive){ 
        if(isBlueprintActive == false){ //if there are no blueprint rooms it lets you spawn one
            Debug.Log(gameObject.name + " was clicked");
            gameManager.BuildRoom(roomNum);
        }
    }
}
