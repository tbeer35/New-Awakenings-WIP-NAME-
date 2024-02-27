using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Universal script for closing any menu windows
public class closeMenu : MonoBehaviour
{
    //Set variables
    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); //find the specific button being used
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find the game manager
        button.onClick.AddListener(close); //create the listener
    }

    //Call when the close button is clicked
    void close(){
        Debug.Log(gameObject.name + " was clicked"); //debug statement
        Debug.Log("this is my tag: " + tag); //debug statement
        if(tag.Equals("endgame")){ //check the tag to see if its the last menu of the game
            gameManager.ReturnToMenu(tag); //if so call the return to start method in gameManager
        }
        gameManager.ReturnToHUD(tag); //otherwise call the return to base hud method in gameManager
    }
}
