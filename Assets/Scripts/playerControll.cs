using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControll : MonoBehaviour
{

    public float velocityMovement;

    public GameObject world;
    public GameObject[] roots;

    public bool onTriggerLeft = false;
    public bool onTriggerRight = false;
    public bool placeRoot = false;

    public int[] seeds;
    public int seedCant = 3;

    void Start()
    {
       
    }

 
    void Update() {

        float movementX = Input.GetAxis("Horizontal") * velocityMovement;

        movementX *= Time.deltaTime;

        if(movementX > 0 && !onTriggerRight)
        {
            transform.Translate(movementX, 0, 0);
        }
        else if(movementX < 0 && !onTriggerLeft)
        {
            transform.Translate(movementX, 0, 0);
        }
        
        if (onTriggerRight && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            world.transform.Rotate(new Vector3(0, 0, 0.1f));
        }
        
        if(onTriggerLeft && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            world.transform.Rotate(new Vector3(0, 0, -0.1f));
        }

        if (Input.GetKeyDown(KeyCode.E) && !placeRoot)
        {
            Instantiate(roots[0], new Vector3(transform.position.x, transform.position.y -0.3f, transform.position.z -3), Quaternion.identity, world.transform);            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("leftSide"))
        {
            onTriggerLeft = true;
        }
        if (collision.CompareTag("rightSide"))
        {
            onTriggerRight = true;
        }
        if (collision.CompareTag("rootMain"))
        {
            placeRoot = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onTriggerRight = false;
        onTriggerLeft = false;
        placeRoot = false;
    }

    private void OnMouseDown()
    {
        Debug.Log("player");

    }
}
