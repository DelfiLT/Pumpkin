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
    }

    // Update is called once per frame
    void Update()
    {
        
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("rootMain") || collision.CompareTag("rootSecond"))
        {
            materialRender.color = new Color(255, 255, 255, 255);
            pumpkingScript actualpumpkingScript = collision.gameObject.GetComponentInParent<pumpkingScript>();
            actualpumpkingScript.ChangeType(materialType);
        }
    }
}
