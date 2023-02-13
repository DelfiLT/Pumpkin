using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpkingTutorialScript : MonoBehaviour
{
    public int pumpkingState;
    public int pumpkingCount;
    SpriteRenderer actualSprite;

    public Sprite[] pumpkingSprites;
    // Seed = 0
    // Initial Pump = 1
    // Pumpking = 2

    // Fosil = 3
    // Iron Pump = 4
    // Oil Pump = 5
    // Sand Pump = 6
    // Lose = 7



    public int rootLevel;

    public GameObject firstRoot;

    // Start is called before the first frame update
    void Start()
    {
        pumpkingState = 0;
        actualSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rootLevel == 5)
        {
            rootLevel = 6;
            gameManagerTutorial.Instance.pumpkingCant--;
        }
    }
    public void changeState()
    {
        if(pumpkingState < 2)
        {
            pumpkingState++;
            actualSprite.sprite = pumpkingSprites[pumpkingState];
            gameManagerTutorial.Instance.waterCant--;
            gameManagerTutorial.Instance.awa.text = $"{gameManagerTutorial.Instance.waterCant}";
        }
        else if (pumpkingState == 2)
        {
            Instantiate(firstRoot, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), Quaternion.identity, transform);
            pumpkingState = 3;
        }
        Debug.Log("pumpkingState: "+ getCurrentState());
    }

    public int  getCurrentState(){
        return pumpkingState;
    }

    public void ChangeType(int materialType)
    {
        gameManagerTutorial.Instance.pumpkingCant--;
        switch (materialType)
        {
            case 0:
                rootLevel = 6;
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                break;

            case 1:
                rootLevel = 6;
                gameManagerTutorial.Instance.seedsCant++;
                gameManagerTutorial.Instance.ironCant++;
                gameManagerTutorial.Instance.semillita.text = $"{gameManagerTutorial.Instance.seedsCant}";
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                gameManagerTutorial.Instance.iron.color = new Color(255, 255, 255, 255);
                break;

            case 2:
                rootLevel = 6;
                gameManagerTutorial.Instance.seedsCant++;
                gameManagerTutorial.Instance.oilCant++;
                gameManagerTutorial.Instance.semillita.text = $"{gameManagerTutorial.Instance.seedsCant}";
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                gameManagerTutorial.Instance.oil.color = new Color(255, 255, 255, 255);
                break;

            case 3:
                rootLevel = 6;
                gameManagerTutorial.Instance.seedsCant++;
                gameManagerTutorial.Instance.sandCant++;
                gameManagerTutorial.Instance.semillita.text = $"{gameManagerTutorial.Instance.seedsCant}";
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                gameManagerTutorial.Instance.sand.color = new Color(255, 255, 255, 255);
                break;

            case 4:
                rootLevel = 6;
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                break;

        }
    }
}
