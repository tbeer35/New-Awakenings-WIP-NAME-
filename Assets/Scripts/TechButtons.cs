using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script for the tech tree buttons, calls gameManager to unlock new rooms, buffs, and other tech tree buttons
public class TechButtons : MonoBehaviour
{
    //create variables
    private Button button;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); //find the button
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find the gameManager
        button.onClick.AddListener(PurchaseUpgrade); //create listener
    }

    //Called on click, passes the buttons tag to the gameManager's ProcessUpgrade method
    void PurchaseUpgrade(){
        gameManager.ProcessUpgrade(gameObject.tag);
    }
}
