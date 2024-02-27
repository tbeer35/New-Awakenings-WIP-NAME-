using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script attached to the Ore and Chip buttons in their respective menus, clicking them triggers this script to add the relevant amount of points
public class oreClicker : MonoBehaviour
{
    //create variables
    private Button button;
    private GameManager gameManager;
    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); //find the button
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find the gameManager
        button.onClick.AddListener(CollectResources); //create the listener
    }

    //Method called on click to call the gameManager's UpdateScore method
    void CollectResources(){
        if(gameManager.isGameActive){ //make sure the game is on
            Debug.Log("clicked a thing!!!!"); //debug statement
            gameManager.UpdateScore(pointValue, gameObject.tag); //pass the amount of points earned and the tag which determines the currency awarded
        }
    }
}
