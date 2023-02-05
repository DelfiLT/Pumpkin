using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpkingScript : MonoBehaviour
{
    public int pumpkingState;
    public int pumpkingCount;
    public Sprite[] pumpkingSprites;
    SpriteRenderer actualSprite;



    // Start is called before the first frame update
    void Start()
    {
        actualSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeState()
    {
        if(pumpkingState < 3)
        {
            pumpkingState++;
            actualSprite.sprite = pumpkingSprites[pumpkingState];
            gameManager.Instance.waterCant--;
        }
    }
}
