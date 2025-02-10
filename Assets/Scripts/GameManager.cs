using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;
//This script controls the whole game, many other methods call on it and it 
public class GameManager : MonoBehaviour
{
    //Set Variables
    public List<GameObject> lockP;
    public List<GameObject> rooms;
    public List<Material> skyboxes;
    public bool isGameActive;
    public int oreScore;
    public int chipScore;
    private int orePC;
    private int chipPC;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI buildScoreText;
    public TextMeshProUGUI techScoreText;
    public GameObject HUD;
    public GameObject MainMenu;
    public GameObject StartingStory;
    public GameObject EndingStory;
    public GameObject OreMenu;
    public GameObject ChipMenu;
    public oreClicker OreButton;
    public oreClicker ChipButton;
    public GameObject BuildMenu;
    public GameObject SatMenu;
    public GameObject BuildPanel;
    public GameObject TechTree;
    public TextMeshProUGUI oreTotalText;
    public TextMeshProUGUI orePCText;
    public TextMeshProUGUI chipTotalText;
    public TextMeshProUGUI chipPCText;
    public GameObject Chip2; //THIS COULD ALSO BE A LIST
    public GameObject DoubleOre;
    public GameObject DoubleChip;
    public GameObject TurningCorners;
    public GameObject ServerRoom;
    public GameObject TJunction;
    public GameObject Lab;
    public GameObject CargoBay;
    public GameObject CommunicationsArray;
    public GameObject RoomSmallCorridor; //THIS COULD BE A LIST
    public GameObject RoomLeftTurn;
    public GameObject RoomRightTurn;
    public GameObject RoomServerRoom;
    public GameObject RoomTJunction;
    public GameObject RoomLab;
    public GameObject RoomCargoBay;
    public GameObject RoomCommunicationsArray;
    public int roomNum;
    public bool isBlueprintActive;
    public Transform cameraTransform;
    // Start sets currency, score, ore and chips per click back to their base levels and turns off the permanenet lock points
    // Also sets isGameActive to true and isBlueprintActive to false
    void Start()
    {
        isGameActive = true;
        orePC = 1;
        chipPC = 1;
        oreScore = 0;
        chipScore = 0;
        UpdateScore(0, "ore");
        UpdateScore(0, "chip");
        orePCText.text = "Ore Per Click: " + orePC;
        chipPCText.text = "Chips Per Click: " + chipPC;
        isBlueprintActive = false;
        DisableLockPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This method is called at the start of the game and sets the difficulty
    public void StartGame(string tag){
        switch(tag){ //the tag passed comes from one of the 3 difficulty buttons on the start menu
            case "easy": //for each case
                isGameActive = true; //sets the game to active
                orePC = 5; //sets ore per click
                OreButton.pointValue =5; //sets how much the ore button is worth
                ChipButton.pointValue =5; //sets how much the chip button is worth
                chipPC = 5; //sets chips per click
                RenderSettings.skybox=skyboxes[0]; //each difficulty has a different skybox to show what section of the galaxy its in
                oreScore = 0; //sets the ore score
                chipScore = 0; //sets the chip score
                UpdateScore(0, "ore"); //updates both score boards
                UpdateScore(0, "chip");
                orePCText.text = "Ore Per Click: " + orePC; //updates the HUD displays for score
                chipPCText.text = "Chips Per Click: " + chipPC;
                DisableLockPoints(); //turns of lock points
                Debug.Log("Difficulty is: " + tag); //debug statement
                OpenMenu("lore"); //opens the first story menu of the game
                break;
            case "medium":
                isGameActive = true;
                orePC = 3;
                OreButton.pointValue =3;
                ChipButton.pointValue =3;
                chipPC = 3;
                RenderSettings.skybox=skyboxes[1];
                oreScore = 0;
                chipScore = 0;
                UpdateScore(0, "ore");
                UpdateScore(0, "chip");
                orePCText.text = "Ore Per Click: " + orePC;
                chipPCText.text = "Chips Per Click: " + chipPC;
                DisableLockPoints();
                Debug.Log("Difficulty is: " + tag);
                OpenMenu("lore");
                break;
            case "hard":
                isGameActive = true;
                orePC = 1;
                chipPC = 1;
                RenderSettings.skybox=skyboxes[2];
                oreScore = 0;
                chipScore = 0;
                UpdateScore(0, "ore");
                UpdateScore(0, "chip");
                orePCText.text = "Ore Per Click: " + orePC;
                chipPCText.text = "Chips Per Click: " + chipPC;
                DisableLockPoints();
                Debug.Log("Difficulty is: " + tag);
                OpenMenu("lore");
                break;
        }
    }

    //Updates the score displayed on the HUD
    public void UpdateScore(int scoreToAdd, string tag){ //takes in the new score and a tag for which score to update, chip or ore
        if(tag.Equals("ore")){ 
            oreScore += scoreToAdd; //adds the new value to the old
            oreTotalText.text = "Ore Available: " + oreScore; //changes the display text
        }else if(tag.Equals("chip")){
            chipScore += scoreToAdd;
            chipTotalText.text = "Chips Available: " + chipScore;
        }else{
            Debug.Log("In the else of update score, shouldn't be here");
        }
        scoreText.text = "Ore Available: " + oreScore + "\nChips Available: " + chipScore;
        buildScoreText.text = "Ore Available: " + oreScore + "\nChips Available: " + chipScore;
        techScoreText.text = "Ore Available: " + oreScore + "\nChips Available: " + chipScore;
    }

    //The tech tree has unlockable multipliers, this method applys them
    public void AddMultiplier(string tag){ //takes in a tag for which multiplier was unlocked
        if(tag.Equals("+2Ore")){ //for each tag
            orePC += 2; //increase the ore or chip per click
            OreButton.pointValue +=2; //increase the buttons point value as well
            orePCText.text = "Ore Per Click: " + orePC; //update the HUD text
        }else if(tag.Equals("+2Chips")){
            chipPC += 2;
            ChipButton.pointValue +=2;
            chipPCText.text = "Chips Per Click: " + chipPC;
        }else if(tag.Equals("x2Ore")){
            orePC = orePC * 2;
            OreButton.pointValue = OreButton.pointValue * 2;
            orePCText.text = "Ore Per Click: " + orePC;
        }else if(tag.Equals("x2Chips")){
            chipPC = chipPC * 2;
            ChipButton.pointValue = ChipButton.pointValue * 2;
            chipPCText.text = "Chips Per Click: " + chipPC;
        }else if(tag.Equals("CargoHold")){
            orePC += 1;
            OreButton.pointValue +=1;
            orePCText.text = "Ore Per Click: " + orePC;
        }else if(tag.Equals("ScienceLab")){
            chipPC += 1;
            ChipButton.pointValue +=1;
            chipPCText.text = "Chips Per Click: " + chipPC;
        }
    }

    //This method opens a menu based on the tag it was passed
    public void OpenMenu(string tag){ //CAN STILL OPEN THE CLICKER INSIDE BUILDMODE
        HUD.gameObject.SetActive(false); //turns off the HUD
        if(tag.Equals("ore")){ //checks each tag an if it matches sets the menu in question to active
            OreMenu.gameObject.SetActive(true);
        }else if(tag.Equals("build")){
            BuildMenu.gameObject.SetActive(true);
            BuildPanel.gameObject.SetActive(true);
            EnableLockPoints();
        }else if(tag.Equals("chip")){
            ChipMenu.gameObject.SetActive(true);
        }else if(tag.Equals("techTree")){
            TechTree.gameObject.SetActive(true);
        }else if(tag.Equals("lore")){
            MainMenu.gameObject.SetActive(false);
            StartingStory.gameObject.SetActive(true);
        }else if(tag.Equals("satarray")){
            SatMenu.gameObject.SetActive(true);
        }else if(tag.Equals("endlore")){
            SatMenu.gameObject.SetActive(false);
            EndingStory.gameObject.SetActive(true);
        }
    }

    //This method reverses what the previous method did
    public void ReturnToHUD(string tag){ //takes in a tag
        if(tag.Equals("oreMenu")){ //checks each tag, if it matches it turns said menu off
            OreMenu.gameObject.SetActive(false);
        }else if(tag.Equals("chip")){
            ChipMenu.gameObject.SetActive(false);
        }else if(tag.Equals("buildMenu")){
            BuildMenu.gameObject.SetActive(false);
            BuildPanel.gameObject.SetActive(false);
            DisableLockPoints();
        }else if(tag.Equals("tech")){
            TechTree.gameObject.SetActive(false);
        }else if(tag.Equals("startlore")){
            StartingStory.gameObject.SetActive(false);
        }else if(tag.Equals("satarray")){
            SatMenu.gameObject.SetActive(false);
        }
        HUD.gameObject.SetActive(true); //at the end it sets the HUD back to active
    }

    //Method to end the game
    public void ReturnToMenu(string tag){
        if(tag.Equals("endgame")){
            EndingStory.gameObject.SetActive(false); //turns off the last story text box
            HUD.gameObject.SetActive(true);
            //MainMenu.gameObject.SetActive(true);
            //THIS NEEDS TO SET SCORES TO 0, DELETE ALL BUILT ROOMS
        }
    }

    //Called by the blueprint room to place the real room
    public void BuildRoom(int room){
        isBlueprintActive = true; //marks that a blueprint room is active
        roomNum = room; //takes in a room number
        switch(roomNum){ //switches thru each and creates the specified room
            case 0:
                Instantiate(rooms[0]);
                break;
            case 1:
                Instantiate(rooms[1]);
                //roomSelected = true;
                break;
            case 2:
                Instantiate(rooms[2]);
                break;
            case 3:
                Instantiate(rooms[3]);
                break;
            case 4:
                Instantiate(rooms[4]);
                break;
            case 5:
                Instantiate(rooms[5]);
                break;
            case 6:
                Instantiate(rooms[6]);
                break;
            case 7:
                Instantiate(rooms[7]);
                break;
        }
    }

    //This method adds all newly created lockpoints to a list so they can be found later
    public int AddToList(GameObject Lockpoint){//THIS NEEDS SOME CLEANING UP
        for(int i = 0; i < lockP.Count; i++){ //loops through all lockpoints
            if(lockP[i] == null){
                Debug.Log("NULL WAS FOUND");
                lockP.Insert(i, Lockpoint); //inserts the new one
                return 1;
            }
        }
        Debug.Log("not null");
        lockP.Insert(lockP.Count, Lockpoint);
        return 0;
    }

    //Turns all lock points in the list off
    void DisableLockPoints(){
        for(int i = 0; i < lockP.Count; i++){ //loops through the list
            if(lockP[i] != null){
                lockP[i].SetActive(false); //sets them as inactive
            }
        }
    }

    //Turns all lock points in the list on
    void EnableLockPoints(){
        for(int i = 0; i < lockP.Count; i++){ //loops through the list
            if(lockP[i] != null){
                lockP[i].SetActive(true); //sets them as active
            }
        }
    }

    //This method takes in the upgrade that was purchased and removes the appropriate amount of currency and then calls another method to implement the upgrade
    public void ProcessUpgrade(string tag){
        switch(tag){ //switches through all possibly upgrades
            case "+2Ore":
                if(oreScore >= 100){ //if they have enough currency
                    UpdateScore(-100, "ore"); //remove the currency
                    AddMultiplier(tag); //call the Addmultiplier method
                    Chip2.gameObject.SetActive(true); //turns on the next ipgrade in the tech tree
                }
                break;
            case "+2Chips":
                if(chipScore >= 100){
                    UpdateScore(-100, "chip");
                    AddMultiplier(tag);
                    DoubleOre.gameObject.SetActive(true);
                }
                break;
            case "x2Ore":
                if(oreScore >= 500 && chipScore >= 200){
                    UpdateScore(-500, "ore");
                    UpdateScore(-200, "chip");
                    AddMultiplier(tag);
                    DoubleChip.gameObject.SetActive(true);
                }
                break;
            case "x2Chips":
                if(oreScore >= 200 && chipScore >= 500){
                    UpdateScore(-200, "ore");
                    UpdateScore(-500, "chip");
                    AddMultiplier(tag);
                }
                break;
            case "SmallCorridor":
                if(oreScore >= 25){
                    UpdateScore(-25, "ore");
                    RoomSmallCorridor.gameObject.SetActive(true); //puts the room into the build menu
                    TurningCorners.gameObject.SetActive(true);
                    ServerRoom.gameObject.SetActive(true);
                }
                break;
            case "CorridorTurn":
                if(oreScore >= 75){
                    UpdateScore(-75, "ore");
                    RoomLeftTurn.gameObject.SetActive(true);
                    RoomRightTurn.gameObject.SetActive(true);
                    TJunction.gameObject.SetActive(true);
                }
                break;
            case "TCorridor":
                if(oreScore >= 150 && chipScore >= 75){
                    UpdateScore(-150, "ore");
                    UpdateScore(-75, "chip");
                    RoomTJunction.gameObject.SetActive(true);
                }
                break;
            case "ServerRoom":
                if(oreScore >= 100){
                    UpdateScore(-100, "ore");
                    RoomServerRoom.gameObject.SetActive(true);
                    Lab.gameObject.SetActive(true);
                    CargoBay.gameObject.SetActive(true);
                }
                break;
            case "ScienceLab":
                if(oreScore >= 250 && chipScore >= 375){
                    UpdateScore(-250, "ore");
                    UpdateScore(-375, "chip");
                    RoomLab.gameObject.SetActive(true);
                    CommunicationsArray.gameObject.SetActive(true);
                }
                break;
            case "CargoHold":
                if(oreScore >= 375 && chipScore >= 250){
                    UpdateScore(-375, "ore");
                    UpdateScore(-250, "chip");
                    RoomCargoBay.gameObject.SetActive(true);
                }
                break;
            case "CommunicationRoom":
                if(oreScore >= 500 && chipScore >= 500){
                    UpdateScore(-500, "ore");
                    UpdateScore(-500, "chip");
                    RoomCommunicationsArray.gameObject.SetActive(true);
                }
                break;
        }
    }

    //The admin mode method simply gives the player a huge amount of ore and chips
    public void GiveAdmin(){
        UpdateScore(10000, "ore");
        UpdateScore(10000, "chip");
    }

    //Reset camera takes the camera transform passed to the gameManager and sets its position to 0,0,0
    public void ResetCamera(){
        cameraTransform.position = new Vector3(0.0f,0.0f,0.0f);
    }
}
