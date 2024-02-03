using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechTreeOpen : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(OpenTechTree);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenTechTree(){
        Debug.Log(gameObject.name + " was clicked");
        gameManager.OpenMenu("techTree");
    }
}
