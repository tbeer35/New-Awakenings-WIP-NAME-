using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechButtons : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(PurchaseUpgrade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PurchaseUpgrade(){
        gameManager.ProcessUpgrade(gameObject.tag);
    }
}
