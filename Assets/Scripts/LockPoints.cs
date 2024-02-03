using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPoints : MonoBehaviour
{
    public GameObject Blueprint;
    private Vector3 distance;
    private Vector3 newPos;
    private Transform greenBall;
    // Start is called before the first frame update
    void Start()
    {
        //BlueprintRooms.instance.unlocked = false;
        BlueprintRooms.instance.ChangeColor("red");
    }

    // Update is called once per frame
    void Update()
    {
        if(BlueprintRooms.instance.unlocked == false){
            float mouseVal = (Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y"))/2;
            if(mouseVal >= 0.3){
                Debug.Log("greenball is equal to: " + greenBall);
                //greenBall.gameObject.SetActive(true);
                BlueprintRooms.instance.unlocked = true;
                BlueprintRooms.instance.ChangeColor("red");
            }
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(transform.forward == other.transform.forward){
            greenBall = other.transform;
            Debug.Log(other.transform);
            distance = transform.position - other.transform.position;
            newPos = Blueprint.transform.position - distance;
            Blueprint.transform.position = newPos;
            BlueprintRooms.instance.unlocked = false;
            BlueprintRooms.instance.ChangeColor("green");
            //greenBall.gameObject.SetActive(false);
        }
    }
    
}
