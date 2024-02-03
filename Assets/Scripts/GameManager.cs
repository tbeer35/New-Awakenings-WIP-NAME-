using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;

public class GameManager : MonoBehaviour
{
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
    //public bool roomSelected;
    public int roomNum;
    // Start is called before the first frame update
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
        DisableLockPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(string tag){
        switch(tag){
            case "easy":
                isGameActive = true;
                orePC = 5;
                OreButton.pointValue =5;
                ChipButton.pointValue =5;
                chipPC = 5;
                RenderSettings.skybox=skyboxes[0];
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


    public void UpdateScore(int scoreToAdd, string tag){
        if(tag.Equals("ore")){
            oreScore += scoreToAdd;
            oreTotalText.text = "Ore Available: " + oreScore;
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

    public void AddMultiplier(string tag){
        if(tag.Equals("+2Ore")){
            orePC += 2;
            OreButton.pointValue +=2;
            orePCText.text = "Ore Per Click: " + orePC;
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

    public void OpenMenu(string tag){ //CAN STILL OPEN THE CLICKER INSIDE BUILDMODE
        HUD.gameObject.SetActive(false);
        if(tag.Equals("ore")){
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

    public void ReturnToHUD(string tag){
        if(tag.Equals("oreMenu")){
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
        HUD.gameObject.SetActive(true);
    }

    public void ReturnToMenu(string tag){
        if(tag.Equals("endgame")){
            EndingStory.gameObject.SetActive(false);
            HUD.gameObject.SetActive(true);
            //MainMenu.gameObject.SetActive(true);
            //THIS NEEDS TO SET SCORES TO 0, DELETE ALL BUILT ROOMS
        }
    }

    public void BuildRoom(int room){
        roomNum = room;
        switch(roomNum){
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

    public int AddToList(GameObject Lockpoint){//THIS NEEDS SOME CLEANING UP
        for(int i = 0; i < lockP.Count; i++){
            if(lockP[i] == null){
                Debug.Log("NULL WAS FOUND");
                lockP.Insert(i, Lockpoint);
                return 1;
            }
        }
        Debug.Log("not null");
        lockP.Insert(lockP.Count, Lockpoint);
        return 0;
    }
    void DisableLockPoints(){
        for(int i = 0; i < lockP.Count; i++){
            if(lockP[i] != null){
                lockP[i].SetActive(false);
            }
        }
    }

    void EnableLockPoints(){
        for(int i = 0; i < lockP.Count; i++){
            if(lockP[i] != null){
                lockP[i].SetActive(true);
            }
        }
    }

    public void ProcessUpgrade(string tag){
        switch(tag){
            case "+2Ore":
                if(oreScore >= 100){
                    UpdateScore(-100, "ore");
                    AddMultiplier(tag);
                    Chip2.gameObject.SetActive(true);
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
                    RoomSmallCorridor.gameObject.SetActive(true);
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

    public void GiveAdmin(){
        UpdateScore(10000, "ore");
        UpdateScore(10000, "chip");
    }
}
