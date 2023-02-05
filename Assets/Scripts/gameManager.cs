using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int seedsCant;
    public int waterCant;
    public GameObject[] awita;
    public int waterSpawnCant = 6;
    



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
        seedsCant = 3;
        waterCant = 0;
        InvokeRepeating("spawnAwita", 10, Random.Range(1, 10));
    }

    void Update()
    {
        
    }

    public void spawnAwita()
    {
        int indexWater = Random.Range(0, awita.Length);
        if (!awita[indexWater].active && waterSpawnCant >= 0)
        {
            awita[indexWater].SetActive(true);
            waterSpawnCant--;
        }
    }

}
