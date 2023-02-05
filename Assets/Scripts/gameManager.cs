using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
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

    
    private static gameManager _instance;
    public static gameManager Instance
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
        pumpkingCant = 0;
        seedsCant = 3;
        waterCant = 0;
        semillita.text = $"{seedsCant}";
        awa.text = $"{waterCant}";
        InvokeRepeating("spawnAwita", 10, Random.Range(1, 10));
    }

    void Update()
    {
        if (seedsCant == 0 && pumpkingCant == 0)
        {
            Debug.Log("LOSE");
            //LOSE
        }

        if (ironCant > 0 && oilCant > 0 && sandCant > 0)
        {
            Debug.Log("WIN");
            //WIN
        }
    }

    public void spawnAwita()
    {
        int indexWater = Random.Range(0, awita.Length);
        if (!awita[indexWater].activeSelf && waterSpawnCant >= 0)
        {
            awita[indexWater].SetActive(true);
            waterSpawnCant--;
        }
    }

}
