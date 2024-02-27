using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script for opening the tech tree
public class TechTreeOpen : MonoBehaviour
{
    //create variables
    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); //find button
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find gameManager
        button.onClick.AddListener(OpenTechTree); //set listener
    }

    //Call the gameManager's OpenMenu method when the button is clicked
    void OpenTechTree(){
        gameManager.OpenMenu("techTree");
    }
}
