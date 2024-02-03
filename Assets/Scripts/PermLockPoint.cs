using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermLockPoint : MonoBehaviour
{
    private bool parentOff;
    public GameObject ParentWall;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        parentOff = false;
        gameManager.AddToList(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other != ParentWall){
            if(transform.forward == other.transform.forward){
                ParentWall.gameObject.SetActive(false);
                parentOff = true;
            }else if(other.tag.Equals("permLockPoint")){
                //ParentWall.gameObject.SetActive(false);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(parentOff == true){
            ParentWall.gameObject.SetActive(true);
            parentOff = false;
        }
    }
}
