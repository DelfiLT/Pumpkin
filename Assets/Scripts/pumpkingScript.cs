using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpkingScript : MonoBehaviour
{
    public int pumpkingState;
    public int pumpkingCount;
    public Sprite[] pumpkingSprites;
    SpriteRenderer actualSprite;

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
        }
        else if (pumpkingState == 2)
        {
            Instantiate(firstRoot, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), Quaternion.identity, transform);
        }
    }
}
