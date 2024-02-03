using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndClicker : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(FinalMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FinalMenu(){
        Debug.Log("last click works");
        gameManager.OpenMenu(gameObject.tag);
    }
}
