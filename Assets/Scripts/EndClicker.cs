using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script assigned to the last button in the game, calls the gameManager's OpenMenu method passing its tag when called
public class EndClicker : MonoBehaviour
{
    //get variables
    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); //find button
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find gameManager
        button.onClick.AddListener(FinalMenu); //create Listener
    }

    //Call the game managers method when pressed
    void FinalMenu(){
        Debug.Log("last click works"); //debug statement
        gameManager.OpenMenu(gameObject.tag);
    }
}
