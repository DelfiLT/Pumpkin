using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialsTutorial : MonoBehaviour
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
            fx_getElement.playFX();
            materialRender.color = new Color(255, 255, 255, 255);
            pumpkingTutorialScript actualpumpkingScript = collision.gameObject.GetComponentInParent<pumpkingTutorialScript>();
            actualpumpkingScript.ChangeType(materialType);
            gameManagerTutorial.Instance.changeState();
        }
    }
}
