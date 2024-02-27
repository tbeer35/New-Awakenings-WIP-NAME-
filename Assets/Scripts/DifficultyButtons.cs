using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script to set the game's difficulty using the start menu's buttons
public class DifficultyButtons : MonoBehaviour
{
    //set variables
    private Button button;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); //find the button
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find the game manager
        button.onClick.AddListener(SetDifficulty); //make the listener
    }

    //When pressed call the gameManager's StartGame method passing the tag of the button pressed
    void SetDifficulty(){
        gameManager.StartGame(gameObject.tag);
    }
}
