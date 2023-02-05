using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControll : MonoBehaviour
{
    //test merge otro
    public float velocityMovement;
    public float testeameesta;

    public GameObject rootPatern;
    public GameObject world;
    public GameObject[] roots;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject pumpking;
    public GameObject temporalPumpking;

    public bool onTriggerLeft = false;
    public bool onTriggerRight = false;
    public bool placeRoot = false;


    public SpriteRenderer spriteRenderer;


    public int[] seeds;
    public int seedCant = 3;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        camera1.SetActive(true);
        camera2.SetActive(false);
    }


    void Update()
    {
        float movementX = Input.GetAxis("Horizontal") * velocityMovement;

        movementX *= Time.deltaTime;

        if (movementX > 0 && !onTriggerRight)
        {
            transform.Translate(movementX, 0, 0);
        }
        else if (movementX < 0 && !onTriggerLeft)
        {
            transform.Translate(movementX, 0, 0);
        }

        if (onTriggerRight && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            world.transform.Rotate(new Vector3(0, 0, 0.1f));
        }

        if (onTriggerLeft && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            world.transform.Rotate(new Vector3(0, 0, -0.1f));
        }

        if (Input.GetKeyDown(KeyCode.E) && !placeRoot && gameManager.Instance.seedsCant > 0)
        {
            Instantiate(pumpking, new Vector3(transform.position.x, transform.position.y -0.3f, transform.position.z), Quaternion.identity, world.transform);
            gameManager.Instance.seedsCant--;
        }

        if (Input.GetKeyDown(KeyCode.Q) && placeRoot && gameManager.Instance.waterCant > 0)
        {
            //anim regar
            temporalPumpking.GetComponent<pumpkingScript>().changeState();
        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) )
        {
            spriteRenderer.flipX = false;git push
            animator.SetBool("moveRight", true);
            animator.SetBool("moveLeft", false);
        
        } else if ( (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            spriteRenderer.flipX = true;
            animator.SetBool("moveLeft", true);
            animator.SetBool("moveRight", false);    
        }else{
            animator.SetBool("moveRight", false);
            animator.SetBool("moveLeft", false);
        }


        //if (Input.GetKeyDown(KeyCode.E) && !placeRoot && gameManager.Instance.seedsCant > 0 && gameManager.Instance.seedsCant <3)
        //{
        //    Instantiate(seed, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, world.transform);
        //    gameManager.Instance.seedsCant--;
        //    gameManager.Instance.pumpkingState[0];
        //    gameManager.Instance.pumpkingCount++;

            //    if(Input.GetKeyDown(KeyCode.E) && gameManager.Instance.waterCant > 0) 
            //    {
            //        gameManager.Instance.pumpkingState[]
            //    }

            //if(Input.GetKeyDown.R) && (gameManager.Instance.pumpkingState[2])
            //{
            //    GameObject rootFather = Instantiate(rootPatern, new Vector3(transform.position.x, transform.position.y - 0.35f, transform.position.z - 3), Quaternion.identity, world.transform);
            //    Instantiate(roots[0], new Vector3(rootFather.transform.position.x, rootFather.transform.position.y, rootFather.transform.position.z), Quaternion.identity, rootFather.transform);
            //}

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camera2.SetActive(true);
            camera1.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("leftSide"))
        {
            onTriggerLeft = true;
            transform.localEulerAngles = new Vector3(0, 0, 15);
        }
        if (collision.CompareTag("rightSide"))
        {
            onTriggerRight = true;
            transform.localEulerAngles = new Vector3(0, 0, -15);
        }
        if (collision.CompareTag("rootMain"))
        {
            temporalPumpking = collision.gameObject;
            placeRoot = true;

        }
        if (collision.CompareTag("awita"))
        {
            collision.gameObject.SetActive(false);
            gameManager.Instance.waterSpawnCant++;
            gameManager.Instance.waterCant++;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onTriggerRight = false;
        onTriggerLeft = false;
        placeRoot = false;
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    private void OnMouseDown()
    {
        Debug.Log("player");

    }
}
