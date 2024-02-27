using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Simple script that adds a listener onto the admin mode button which calls a basic function to call a function of the game manager to enable admin mode
public class AdminMode : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    // initialize the button, find the game manager, add the listener
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(GetMoney);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //calls the gameManager's Give admin function
    void GetMoney(){
        gameManager.GiveAdmin();
    }
}
