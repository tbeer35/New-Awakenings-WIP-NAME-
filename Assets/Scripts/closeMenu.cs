using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeMenu : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(close);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void close(){
        Debug.Log(gameObject.name + " was clicked");
        Debug.Log("this is my tag: " + tag);
        if(tag.Equals("endgame")){
            gameManager.ReturnToMenu(tag);
        }
        gameManager.ReturnToHUD(tag);
    }
}
