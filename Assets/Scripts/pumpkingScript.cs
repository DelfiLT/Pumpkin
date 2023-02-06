using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpkingScript : MonoBehaviour
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
            gameManager.Instance.pumpkingCant--;
        }
    }
    public void changeState()
    {
        if(pumpkingState < 2)
        {
            pumpkingState++;
            actualSprite.sprite = pumpkingSprites[pumpkingState];
            gameManager.Instance.waterCant--;
            gameManager.Instance.awa.text = $"{gameManager.Instance.waterCant}";
        }
        else if (pumpkingState == 2)
        {
            Instantiate(firstRoot, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), Quaternion.identity, transform);
        }
    }

    public void ChangeType(int materialType)
    {
        gameManager.Instance.pumpkingCant--;
        switch (materialType)
        {
            case 0:
                rootLevel = 6;
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                break;

            case 1:
                rootLevel = 6;
                gameManager.Instance.seedsCant++;
                gameManager.Instance.ironCant++;
                gameManager.Instance.semillita.text = $"{gameManager.Instance.seedsCant}";
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                gameManager.Instance.iron.color = new Color(255, 255, 255, 255);
                break;

            case 2:
                rootLevel = 6;
                gameManager.Instance.seedsCant++;
                gameManager.Instance.oilCant++;
                gameManager.Instance.semillita.text = $"{gameManager.Instance.seedsCant}";
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                gameManager.Instance.oil.color = new Color(255, 255, 255, 255);
                break;

            case 3:
                rootLevel = 6;
                gameManager.Instance.seedsCant++;
                gameManager.Instance.sandCant++;
                gameManager.Instance.semillita.text = $"{gameManager.Instance.seedsCant}";
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                gameManager.Instance.sand.color = new Color(255, 255, 255, 255);
                break;

            case 4:
                rootLevel = 6;
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                break;

        }
    }
}
