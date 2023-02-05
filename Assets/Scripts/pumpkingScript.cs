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
        switch (materialType)
        {
            case 0:
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                break;

            case 1:
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                break;

            case 2:
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                break;

            case 3:
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                break;

            case 4:
                actualSprite.sprite = pumpkingSprites[materialType + 3];
                break;

        }
    }
}
