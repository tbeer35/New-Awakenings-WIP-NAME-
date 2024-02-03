using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicker : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        if(gameManager.isGameActive){
            Debug.Log("clicked the: " + gameObject.name);
            gameManager.OpenMenu(gameObject.tag);
        }
    }
}
