using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterCamera : MonoBehaviour
{
     //create variables
    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); //find button
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find gameManager
        button.onClick.AddListener(Center); //set listener
    }

    // Update is called once per frame
    void Center()
    {
        gameManager.ResetCamera();
        //gameManager.ResetCamera();
    }
}
