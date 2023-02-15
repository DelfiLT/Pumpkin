using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControll : MonoBehaviour
{
    //test merge otro
    public float velocityMovement;

    public GameObject rootPatern;
    public GameObject world;
    public GameObject[] roots;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject pumpking;
    public GameObject temporalPumpking;
    public GameObject canvas;

    public bool onTriggerLeft = false;
    public bool onTriggerRight = false;
    public bool placeRoot = false;

    public Animator naveanim;

    public SpriteRenderer spriteRenderer;


    public int[] seeds;
    public int seedCant = 3;

    Animator animator;
    AudioSource[] audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        camera1.SetActive(true);
        camera2.SetActive(false);
        audioSource = GetComponents<AudioSource>();

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
            world.transform.Rotate(new Vector3(0, 0, 0.25f));
        }

        if (onTriggerLeft && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            world.transform.Rotate(new Vector3(0, 0, -0.25f));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (placeRoot && gameManager.Instance.waterCant > 0)
            {
                //anim regar
                pumpkingScript thispumpkingScript = temporalPumpking.GetComponent<pumpkingScript>();
                if (thispumpkingScript != null)
                {
                    fx_dropWater.playFX();
                    thispumpkingScript.changeState();
                }
            }
            else if (!placeRoot && gameManager.Instance.seedsCant > 0)
            {   
                Instantiate(pumpking, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity, world.transform);
                
                gameManager.Instance.seedsCant--;
                gameManager.Instance.pumpkingCant++;
                gameManager.Instance.semillita.text = $"{gameManager.Instance.seedsCant}";
            }
        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) )
        {
            spriteRenderer.flipX = false;
            animator.SetBool("moveRight", true);
            animator.SetBool("moveLeft", false);
            audioSource[0].Play();


        } else if ( (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            spriteRenderer.flipX = true;
            animator.SetBool("moveLeft", true);
            animator.SetBool("moveRight", false);
            audioSource[0].Play();
        }
        else{
            audioSource[1].Stop();
            //audioSource[1].Play();
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
            transform.localEulerAngles = new Vector3(0, 0, 9);
        }
        if (collision.CompareTag("rightSide"))
        {
            onTriggerRight = true;
            transform.localEulerAngles = new Vector3(0, 0, -9);
        }
        if (collision.CompareTag("rootMain"))
        {
            
            temporalPumpking = collision.gameObject;
            placeRoot = true;

        }
        if (collision.CompareTag("awita"))
        {   
            Debug.Log("Opa la la");
            pickwater_fx.playFX();
            collision.gameObject.SetActive(false);
            gameManager.Instance.waterSpawnCant++;
            gameManager.Instance.waterCant++;
            gameManager.Instance.awa.text = $"{gameManager.Instance.waterCant}";
        }
        
        if(collision.CompareTag("nave") && gameManager.Instance.win)
        {
            canvas.SetActive(false);
            velocityMovement = 0;
            gameManager.Instance.seedsCant = 0;
            gameManager.Instance.pumpkingCant = 1;
            Debug.Log("animNave");
            Invoke("gotowin", 3);
            naveanim.SetTrigger("fin");
        }
    }

    void gotowin()
    {
        SceneManager.LoadScene("Win");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("rightSide") || collision.CompareTag("leftSide"))
        {
            onTriggerRight = false;
            onTriggerLeft = false;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (collision.CompareTag("rootMain"))
        {
            placeRoot = false;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("rootMain"))
    //    {
    //        placeRoot = true;

    //    }
    //}

    private void OnMouseDown()
    {
        Debug.Log("player");

    }
}
