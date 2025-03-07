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
        if(tag.Equals("endgame")){ //check the tag to see if its the last menu of the game
            gameManager.ReturnToMenu(tag); //if so call the return to start method in gameManager
        }
        if(tag.Equals("buildMenu")){ //check to see if its the building menu
            if(gameManager.isBlueprintActive == false){ //there have to be no blueprint rooms active to close the building menu
                gameManager.ReturnToHUD(tag);
            }else{
                return;
            }
        }
        gameManager.ReturnToHUD(tag); //otherwise call the return to base hud method in gameManager
    }
}
