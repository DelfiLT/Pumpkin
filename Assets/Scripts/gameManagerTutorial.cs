using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManagerTutorial : MonoBehaviour
{
    public int ironCant;
    public int oilCant;
    public int sandCant;
    public int seedsCant;
    public int waterCant;
    public int pumpkingCant;
    public GameObject[] awita;
    public int waterSpawnCant = 6;
    public TextMeshProUGUI awa;
    public TextMeshProUGUI semillita;
    public TextMeshProUGUI dialogMainText;
    public TextMeshProUGUI continueTutorial;
    public Image iron;
    public Image oil;
    public Image sand;

    public GameObject readyDilog;
    public bool win = false;
    private int[] readingDialogsPosition = {0,1,3,5,6,8,10,13,14,15,17,18,19};
    private string[] dialog_text = {"Welcome, I will show you how to play this game",
                                    "First, will start with the movements",
                                    "press A (or LEFT) key to move left and D (or RIGHT) key to move right",
                                    "Good now, we'll check the camera",
                                    "Press 1 and 2 key to toggle near and far camera",
                                    "Great, Now we need to collect some materials to repair my spaceship",
                                    "First we need to set our position over a cave under the earth",
                                    "place me over a cave",
                                    "now, we need to plant a seed",
                                    "press E to plant a seed",
                                    "Well done, now it's time to water the seed. First, we need to catch some water drops",
                                    "move around the world until you get some water",
                                    "There you go, now, go back to the seed and water it with E key",
                                    "Fantastic, to make the pumpkin grows, collect more water drops and ...",
                                    "water the pumpkin until you see the roots below it (2 left)",
                                    "Ok, now, we will try to reach one of the caves using the roots",
                                    "use the mouse's left button to click the branch you want to grow to reach the closest cave",
                                    "that's great, you found a material. If this is a required material, you also will ...",
                                    "receive a seed. If not, you will receive nothing and need to keep looking ...",
                                    "until you find all needed ones or you are out of seeds",
                                    "That's all, you can presse SPACE key to go to the first level or ESC to Exit"};
    
    public int currentDialog = 0; 
    public enum tutorialState {READING,MOVING,ZOOMING,FINDING_CAVE,PLANTING_SEED,SEARCHING_WATER,WATERING_SEED,WATERING_PUMPKIN,GROWING_ROOTS,TUTORIAL_FINISHED};
    private tutorialState currentTutorialState = tutorialState.READING;
    
    private static gameManagerTutorial _instance;
    public static gameManagerTutorial Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Instance exists");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        win = false;
        pumpkingCant = 0;
        seedsCant = 3;
        waterCant = 0;
        semillita.text = $"{seedsCant}";
        awa.text = $"{waterCant}";
        updateDialogText(currentDialog);
        InvokeRepeating("spawnAwita", 10, Random.Range(1, 10));
    }

    void Update()
    {

        if (getCurrentTutorialState() == tutorialState.READING && Input.GetKeyDown(KeyCode.Space) ){
            
            if (currentDialog < dialog_text.Length - 1){
                changeState();
            }
        }else if (getCurrentTutorialState() == tutorialState.TUTORIAL_FINISHED){
            if (Input.GetKeyDown(KeyCode.Space)){
              SceneManager.LoadScene("Game");
            }
            else if (Input.GetKeyDown(KeyCode.Escape)){
                SceneManager.LoadScene("Menu");
            }
        }

        if (seedsCant == 0 && pumpkingCant <= 0)
        {
            Debug.Log("LOSE");
            SceneManager.LoadScene("Loose");
            //LOSE
        }

        if (ironCant > 0 && oilCant > 0 && sandCant > 0)
        {
            Debug.Log("WIN");
            readyDilog.SetActive(true);
            win = true;
            //SceneManager.LoadScene("Win");
            //WIN
        }
    }


    private void updateDialogText(int textId){
         dialogMainText.text = dialog_text[textId]; 
    }

    public void spawnAwita()
    {
        int indexWater = Random.Range(0, awita.Length);
        if (!awita[indexWater].activeSelf && waterSpawnCant >= 0)
        {
            fx_waterDropAppears.playFX();
            awita[indexWater].SetActive(true);
            waterSpawnCant--;
        }
    }

    
        public tutorialState getCurrentTutorialState(){
        return currentTutorialState;
    }
    
    public void setCurrentTutorialState(tutorialState newState){
        currentTutorialState = newState;
    }
    
    public void changeState(){
        currentDialog += 1;
        
        continueTutorial.enabled = false;
        switch (currentDialog)
        {
            case 2: 
                setCurrentTutorialState(tutorialState.MOVING);
                break;
            case 4:
                setCurrentTutorialState(tutorialState.ZOOMING);
                break;
            case 7:
                setCurrentTutorialState(tutorialState.FINDING_CAVE);
                break;
            case 9:
                setCurrentTutorialState(tutorialState.PLANTING_SEED);
                break;
            case 11:
                setCurrentTutorialState(tutorialState.SEARCHING_WATER);
                break;
            case 12:
                setCurrentTutorialState(tutorialState.WATERING_SEED);
                break;
            case 14:
                setCurrentTutorialState(tutorialState.WATERING_PUMPKIN);
                break;
            case 16:
                setCurrentTutorialState(tutorialState.GROWING_ROOTS);
                break;
            case 20:
                setCurrentTutorialState(tutorialState.TUTORIAL_FINISHED);
                break;
            default:
                continueTutorial.enabled = true;
                setCurrentTutorialState(tutorialState.READING);
                break;

        }
        updateDialogText(currentDialog);
    } 

}
