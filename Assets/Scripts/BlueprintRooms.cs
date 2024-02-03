using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintRooms : MonoBehaviour
{
    public static BlueprintRooms instance;
    private GameManager gameManager;
    public Vector3 position = new Vector3(0,0,0);
    public Vector3 oldPosition = new Vector3(0,0,0);
    public Quaternion oldRotation;
    public bool unlocked;
    public GameObject realRoom;
    private MaterialPropertyBlock matBlock;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        instance = this;
        transform.position = position;
        unlocked = true;
    }

    void Update()
    {
        if(unlocked){
            ProcessInput();
        }
        if(Input.GetMouseButtonDown(0)){
            if(unlocked == false){
                //ANOTHER IF TO MAKE SURE THEY HAVE ENOUGH CURRENCY WITH AN ELSE THAT PRINTS AN ERROR TO THE SCREEN
                CheckCurrency();
            }
        }else if(Input.GetMouseButtonDown(1)){
            if(unlocked == true){
                Destroy(gameObject);
            }
        }
    }

    void ProcessInput(){
        Vector3 mouse = Input.mousePosition;
        LayerMask mask = LayerMask.GetMask("BuildMode");
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, mask))
        {
        transform.position = hit.point;
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            transform.Rotate(0, 90, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.GetComponent<Collider>().name);
    }

    public void ChangeColor(string color)
    {
        if (matBlock == null)
            matBlock = new MaterialPropertyBlock();
        for (int i = 0; i < transform.childCount; i++){
            GameObject child = transform.GetChild(i).gameObject;
            for (int j = 0; j < child.transform.childCount; j++){
                GameObject child2 = child.transform.GetChild(j).gameObject;
                for (int k = 0; k < child2.transform.childCount; k++){
                    GameObject child3 = child2.transform.GetChild(k).gameObject;
                    try{
                    MeshRenderer my_renderer2 = child3.GetComponent<MeshRenderer>();
                    if(color.Equals("green")){ 
                            for(int cnt = 0; cnt < my_renderer2.sharedMaterials.Length; cnt++){
                                matBlock.SetColor("_Color", Color.green);
                                my_renderer2.SetPropertyBlock(matBlock, cnt);
                            }
                    }else if(color.Equals("red")){
                            for(int cnt = 0; cnt < my_renderer2.materials.Length; cnt++){
                                matBlock.SetColor("_Color", Color.red);
                                my_renderer2.SetPropertyBlock(matBlock, cnt);
                            }
                    }
                    }catch{
                        Debug.Log("No Render");
                    }
                    
                } 
                try{
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

    public void CheckCurrency(){
        switch(gameObject.tag){
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
