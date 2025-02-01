using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for handling the blueprint rooms; moving them, changing their color, and placing the real rooms

public class BlueprintRooms : MonoBehaviour
{
    //Set variables
    public static BlueprintRooms instance;
    private GameManager gameManager;
    public Vector3 position = new Vector3(0,0,0);
    public Vector3 oldPosition = new Vector3(0,0,0);
    public Quaternion oldRotation;
    public bool unlocked;
    public GameObject realRoom;
    private MaterialPropertyBlock matBlock;

    //Find the game manager, set the instance and the position, and set unlocked to true on start
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        instance = this;
        transform.position = position;
        unlocked = true;
    }

    //called every frame to see what the player is doing
    void Update()
    {
        if(unlocked){ //if it isn't attached to a lockpoint 
            ProcessInput(); //call the ProcessInput Method
        }
        if(Input.GetMouseButtonDown(0)){ //if the player left clicked to place the room
            if(unlocked == false){ //and they're on a lockpoint (valid building spot)
                //ANOTHER IF TO MAKE SURE THEY HAVE ENOUGH CURRENCY WITH AN ELSE THAT PRINTS AN ERROR TO THE SCREEN
                CheckCurrency(); //call the CheckCurrency funtion to place the room
            }
        }else if(Input.GetMouseButtonDown(1)){ //if the player right clicked to delete the blueprint
            if(unlocked == true){ //and it's not on a lockpoint
                Destroy(gameObject); //destroy the blueprint
            }
        }
    }

    //Uses raycast to move the blueprint around and if the player presses 'R' it rotates it
    void ProcessInput(){
        Vector3 mouse = Input.mousePosition;
        LayerMask mask = LayerMask.GetMask("BuildMode");
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, mask)){
            transform.position = hit.point; //move the blueprint to where the raycast points
        }

        if (Input.GetKeyDown(KeyCode.R)) { //If they hit R
            transform.Rotate(0, 90, 0); //Rotate the blueprint 90 degrees
        }
    }

    //debugging method to check what the blueprint touched
    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.GetComponent<Collider>().name);
    }
    */

    /*Method to change the color from red if the blueprint is in a nonvalid placement to green if the placement is valid
    * Needs to go through each prefab part by part and change the color of the matBlock
    * Some prefabs have up to 3 children layers so it needs to be able to reach down
    */
    public void ChangeColor(string color)
    {
        if (matBlock == null)
            matBlock = new MaterialPropertyBlock();
        for (int i = 0; i < transform.childCount; i++){ //loop through all children of the main prefab
            GameObject child = transform.GetChild(i).gameObject; //assign the current child to a variable
            for (int j = 0; j < child.transform.childCount; j++){ //loop through all children of the current child
                GameObject child2 = child.transform.GetChild(j).gameObject; //assign the current child's child to a variable
                for (int k = 0; k < child2.transform.childCount; k++){ //loop through all "grandchildren" of the current child
                    GameObject child3 = child2.transform.GetChild(k).gameObject; //assign the current child's "grandchild" to a variable
                    try{ //try catch in place incase the child doesn't have a render
                    MeshRenderer my_renderer2 = child3.GetComponent<MeshRenderer>(); //set the MeshRenderer to a variable
                    if(color.Equals("green")){ //if the passed string of what color to change it to is green
                            for(int cnt = 0; cnt < my_renderer2.sharedMaterials.Length; cnt++){ //find all pieces of the render
                                matBlock.SetColor("_Color", Color.green); //set them to green
                                my_renderer2.SetPropertyBlock(matBlock, cnt); //repackage
                            }
                    }else if(color.Equals("red")){ //if the passed string of what color to change it to is red
                            for(int cnt = 0; cnt < my_renderer2.materials.Length; cnt++){
                                matBlock.SetColor("_Color", Color.red);
                                my_renderer2.SetPropertyBlock(matBlock, cnt);
                            }
                    }
                    }catch{
                        Debug.Log("No Render"); 
                    }
                    
                } 
                try{ //repeat above but for one child up, never for the first child because they're just empty game object parents
                    MeshRenderer my_renderer = child2.GetComponent<MeshRenderer>();
                    if(color.Equals("green")){
                            for(int cnt = 0; cnt < my_renderer.materials.Length; cnt++){
                                matBlock.SetColor("_Color", Color.green);
                                my_renderer.SetPropertyBlock(matBlock, cnt);
                            }
                    }else if(color.Equals("red")){
                            for(int cnt = 0; cnt < my_renderer.materials.Length; cnt++){
                                matBlock.SetColor("_Color", Color.red);
                                my_renderer.SetPropertyBlock(matBlock, cnt);
                            }
                    }
                }catch{
                        Debug.Log("No Render");
                }
                    
            } 
        }
    }

    //simple method to check if the player has the right amount of ore or chips to buy the building the want to place 
    public void CheckCurrency(){
        switch(gameObject.tag){ //switch on the tag of the game object, for each possible tag check if they have enough currency, remove the currency, create the physical building, delete the blueprint
            case "SmallCorridor":
                if(gameManager.oreScore >= 50){
                    gameManager.UpdateScore(-50,"ore");
                    Instantiate(realRoom, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                break;
            case "CorridorTurn":
                if(gameManager.oreScore >= 125){
                    gameManager.UpdateScore(-125,"ore");
                    Instantiate(realRoom, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                break;
            case "ServerRoom":
                if(gameManager.oreScore >= 200){
                    gameManager.UpdateScore(-200,"ore");
                    Instantiate(realRoom, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                break;
            case "ScienceLab":
                if(gameManager.chipScore >= 150 && gameManager.oreScore >= 250){
                    gameManager.UpdateScore(-150,"chip");
                    gameManager.UpdateScore(-250,"ore");
                    Instantiate(realRoom, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                break;
            case "TCorridor":
                if(gameManager.chipScore >= 50 && gameManager.oreScore >= 225){
                    gameManager.UpdateScore(-50,"chip");
                    gameManager.UpdateScore(-225,"ore");
                    Instantiate(realRoom, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                break;
            case "CargoHold":
                if(gameManager.chipScore >= 100 && gameManager.oreScore >= 100){
                    gameManager.UpdateScore(-100,"chip");
                    gameManager.UpdateScore(-250,"ore");
                    Instantiate(realRoom, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                break;
            case "CommunicationRoom":
                if(gameManager.chipScore >= 1000 && gameManager.oreScore >= 1000){
                    gameManager.UpdateScore(-1000,"chip");
                    gameManager.UpdateScore(-1000,"ore");
                    Instantiate(realRoom, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                break;
        }
        //Instantiate(realRoom, transform.position, transform.rotation);
        //Destroy(gameObject);
    }
    
}
