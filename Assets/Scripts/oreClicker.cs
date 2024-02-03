using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oreClicker : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(CollectResources);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CollectResources(){
        if(gameManager.isGameActive){
            Debug.Log("clicked a thing!!!!");
            gameManager.UpdateScore(pointValue, gameObject.tag);
        }
    }
}
