using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControlTutorial : MonoBehaviour
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
    private int movedRight = 0;
    private int movedLeft = 0;
    private int cameraPressed = 0;
    private bool caveFound = false;
    private bool firstDropTaken = false;
    private bool seedWatered = false;
    private bool rootAppeared = false;
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
        
        switch (gameManagerTutorial.Instance.getCurrentTutorialState())
        {
            case gameManagerTutorial.tutorialState.MOVING:
                moveRobot();
                if(movedLeft >= 100 && movedRight >= 100){
                    gameManagerTutorial.Instance.changeState();
                    animator.SetBool("moveRight", false);
                    animator.SetBool("moveLeft", false);
                }
                break;
            case gameManagerTutorial.tutorialState.ZOOMING:
                if (Input.GetKeyDown(KeyCode.Alpha1)){
                    activeCam1();
                    if(cameraPressed == 2){
                        gameManagerTutorial.Instance.changeState();
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha2)){
                    cameraPressed = 2;
                    activeCam2();
                }
                break;
            case gameManagerTutorial.tutorialState.FINDING_CAVE:
                moveRobot();
                if (Input.GetKeyDown(KeyCode.Alpha1)){
                    activeCam1();
                }
                if (Input.GetKeyDown(KeyCode.Alpha2)){
                    activeCam2();
                }
                if (caveFound){
                    gameManagerTutorial.Instance.changeState();
                    animator.SetBool("moveRight", false);
                    animator.SetBool("moveLeft", false);
                }
                break;
            
            case gameManagerTutorial.tutorialState.PLANTING_SEED:
                 if (Input.GetKeyDown(KeyCode.E)){
                    plantSeed();
                    gameManagerTutorial.Instance.changeState();
                }
                break;
            case gameManagerTutorial.tutorialState.SEARCHING_WATER:
                moveRobot();
                if (Input.GetKeyDown(KeyCode.Alpha1)){
                    activeCam1();
                }
                if (Input.GetKeyDown(KeyCode.Alpha2)){
                    activeCam2();
                }
                if(firstDropTaken){
                    gameManagerTutorial.Instance.changeState();
                    animator.SetBool("moveRight", false);
                    animator.SetBool("moveLeft", false);
                }
                break;
            case gameManagerTutorial.tutorialState.WATERING_SEED:
                moveRobot();
                if (Input.GetKeyDown(KeyCode.Alpha1)){
                    activeCam1();
                }
                if (Input.GetKeyDown(KeyCode.Alpha2)){
                    activeCam2();
                }
                if (Input.GetKeyDown(KeyCode.E)){
                     if (placeRoot && gameManagerTutorial.Instance.waterCant > 0)
                    {   
                        watering();
                    }
                    
                }
                if (seedWatered){
                    gameManagerTutorial.Instance.changeState();
                    animator.SetBool("moveRight", false);
                    animator.SetBool("moveLeft", false);
                }
                break;
            case gameManagerTutorial.tutorialState.WATERING_PUMPKIN:
                moveRobot();
                if (Input.GetKeyDown(KeyCode.Alpha1)){
                    activeCam1();
                }
                if (Input.GetKeyDown(KeyCode.Alpha2)){
                    activeCam2();
                }
                if (Input.GetKeyDown(KeyCode.E)){
                     if (placeRoot && gameManagerTutorial.Instance.waterCant > 0)
                    {   
                        watering();
                    }
                    
                }
                if (rootAppeared){
                    gameManagerTutorial.Instance.changeState();
                    animator.SetBool("moveRight", false);
                    animator.SetBool("moveLeft", false);
                }
                break;
            case gameManagerTutorial.tutorialState.TUTORIAL_FINISHED:
                moveRobot();
                break;
        }
    }

    private void plantSeed(){
        Instantiate(pumpking, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity, world.transform);
        gameManagerTutorial.Instance.seedsCant--;
        gameManagerTutorial.Instance.pumpkingCant++;
        gameManagerTutorial.Instance.semillita.text = $"{gameManagerTutorial.Instance.seedsCant}";
    }

    private void watering(){
         //anim regar
        pumpkingTutorialScript thispumpkingScript = temporalPumpking.GetComponent<pumpkingTutorialScript>();
        if (thispumpkingScript != null)
        {
            fx_dropWater.playFX();
            thispumpkingScript.changeState();
            if(thispumpkingScript.getCurrentState() == 3){
                rootAppeared = true;
            }
            if(gameManagerTutorial.Instance.getCurrentTutorialState() == gameManagerTutorial.tutorialState.WATERING_SEED){
                seedWatered = true;
            }
        }
    }

 
    private void moveRobot(){
        float movementX = Input.GetAxis("Horizontal") * velocityMovement;
        
        if(gameManagerTutorial.Instance.getCurrentTutorialState() == gameManagerTutorial.tutorialState.MOVING){
            if(Input.GetAxis("Horizontal") > 0){
                movedRight += 1;
            }else if(Input.GetAxis("Horizontal") < 0){
                movedLeft += 1;
            }
        }


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
    
    }


    private void activeCam1(){
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    private void activeCam2(){
        camera2.SetActive(true);
        camera1.SetActive(false);
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
            if(gameManagerTutorial.Instance.getCurrentTutorialState() == gameManagerTutorial.tutorialState.SEARCHING_WATER){
                Debug.Log("ok, estaría andando bien");
                firstDropTaken = true;

            }

            pickwater_fx.playFX();
            collision.gameObject.SetActive(false);
            gameManagerTutorial.Instance.waterSpawnCant++;
            gameManagerTutorial.Instance.waterCant++;
            gameManagerTutorial.Instance.awa.text = $"{gameManagerTutorial.Instance.waterCant}";
        }
         if (collision.CompareTag("Material") && gameManagerTutorial.Instance.getCurrentTutorialState() == gameManagerTutorial.tutorialState.FINDING_CAVE){   
            caveFound = true;
            collision.GetComponent<BoxCollider2D>().enabled = false;

        }
        
        //if(collision.CompareTag("nave") && gameManagerTutorial.Instance.win)
        if(collision.CompareTag("nave"))
        {
            canvas.SetActive(false);
            velocityMovement = 0;
            gameManagerTutorial.Instance.seedsCant = 0;
            gameManagerTutorial.Instance.pumpkingCant = 1;
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
