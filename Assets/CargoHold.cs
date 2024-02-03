using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoHold : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.AddMultiplier(tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
