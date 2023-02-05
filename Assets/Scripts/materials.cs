using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materials : MonoBehaviour
{
    public int materialType;
    public Sprite[] materialsSprite;
    public SpriteRenderer materialRender;

    //Fosil = 0

    //Iron = 1
    //Oil = 2
    //Sand = 3

    //Moss = 4

    // Start is called before the first frame update
    void Start()
    {
        materialRender.sprite = materialsSprite[materialType];
        materialRender.color = new Color(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
 
    }
}
