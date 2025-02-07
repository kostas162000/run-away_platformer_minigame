using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public bool death; //state of player (dead or alive)
    [SerializeField] private int deathcount = 0; //counter for deaths
    //[SerializeField] 
    private float timer=0.8f;
    

    private Vector2 startingposition; //starting position of player for respawn
    public bool playerRespawned; //check if player respawned for other scripts
    public bool platformToRespawn = false;
    //public bool stalagmiteToRespawn = false;
    private float temp;
    [SerializeField] private int poisonedStatus=0;

    private Animator anim;

    [SerializeField] private GameObject groundCollider;
    [SerializeField] private GameObject deathStateCollider;
    [SerializeField] private CapsuleCollider2D bodyCollider;


    [SerializeField] private GameObject dieMenu;
    [SerializeField] private GameObject permanentDieMenu;

    [SerializeField] private Text output;
    private int livesRemaining = 2;

    public static bool playerEscaped = false;


    [SerializeField] private Animator transAnim;
    public static bool transStart = false;
    public static bool transEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        temp = timer;
        startingposition = transform.position; //initialize starting position
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (death == true)
        {
            output.text = "Remaining lives:" + livesRemaining;

            groundCollider.SetActive(false);
            deathStateCollider.SetActive(true);
            bodyCollider.enabled = false;

            //anim.SetTrigger("tdie");
            

            GetComponent<PlayerMovement>().enabled = false; //when player dies movement script gets disabled, so player cannot move
            playerRespawned = false; //set state as not respawned

            //StartCoroutine(deathAnimation());
            deathAnimation();
            
        }
        else if (death == false)
        {
            groundCollider.SetActive(true);
            deathStateCollider.SetActive(false);
            bodyCollider.enabled = true;
            GetComponent<PlayerMovement>().enabled = true; //when player is not dead movement scripts is enabled, so player is able to move
        }


        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            death = true; //when player collides with these objects dies, so state is set to dead
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            death = true; //when player triggers with these objects dies, so state is set to dead
        }
        else if (collision.gameObject.tag == "Sting")
        {
            if(poisonedStatus == 0)
                poisonedStatus = 1;
            else if(poisonedStatus == 1)
                poisonedStatus = 2;
            
            //poisonedStatus = poisonedStatus +1;
            if (poisonedStatus >= 2)
            {
                death = true;
                poisonedStatus = 0;
            }
        }
        if(collision.gameObject.tag == "ExitMinigame")
        {
            playerEscaped = true;
            //exitMinigame(); 
            StartCoroutine(transitionAnimation());
        }
    }

    public void Respawn()
    {
        //while (playerRespawned == false)
        //{
            //anim.SetBool("die", true);
        //}
        /*timer -= Time.deltaTime;
        if (timer <= 0.0f) //timer for player to respawn 
        {*/
            transform.position = startingposition; //player goes back to starting position
            anim.SetBool("die", false);
            deathcount++; //number of deaths rises
            livesRemaining = 2 - deathcount;
            //timer = temp; //timer return to orignal value
            death = false; //state of plyaer is set to alive
            playerRespawned = true; //player is now respawned
            platformToRespawn = true;
            //stalagmiteToRespawn = true;
            poisonedStatus = 0;
            dieMenu.SetActive(false);
        //}


    }

    /*private IEnumerator deathAnimation() 
    {
        anim.SetBool("die", true);
        yield return new WaitForSeconds(1);
        dieMenu.SetActive(true);
    }*/


    private void deathAnimation()
    {
        anim.SetBool("die", true);
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            timer = temp;
            if (deathcount < 2) //player can respawn 3 times
            {
                dieMenu.SetActive(true);
            }
            else if(deathcount >= 2)
            {

                permanentDieMenu.SetActive(true);
                if (StageController.flagForRespawn == 0)
                {
                    deathcount = 0;
                    transform.position = startingposition;
                    livesRemaining = 2;
                    death = false;
                    playerRespawned = false; 
                    platformToRespawn = false;
                    poisonedStatus = 0;
                    anim.SetBool("die", false);
                    StageController.flagForRespawn = 1;
                    //StageController.buttonToReturnToCheckpoint = false;
                }
            }
        }
    }

    /*private void exitMinigame()
    {
        if (StageController.flagForRespawn == 0)
        {
            //if (EscapeMinigame.transStart)
            //{
                deathcount = 0;
                transform.position = startingposition;
                livesRemaining = 2;
                death = false;
                playerRespawned = false;
                platformToRespawn = false;
                poisonedStatus = 0;
                anim.SetBool("die", false);
                StageController.flagForRespawn = 1;
               // EscapeMinigame.transStart = false;
                //StageController.buttonToReturnToCheckpoint = false;
            //}
        }
    }*/
    private IEnumerator transitionAnimation()
    {
        transAnim.SetTrigger("transitionStart");
        yield return new WaitForSeconds(1.5f);
        transStart = true;
        if (StageController.flagForRespawn == 0)
        {
            //if (EscapeMinigame.transStart)
            //{
            deathcount = 0;
            transform.position = startingposition;
            livesRemaining = 2;
            death = false;
            playerRespawned = false;
            platformToRespawn = false;
            poisonedStatus = 0;
            anim.SetBool("die", false);
            StageController.flagForRespawn = 1;
            // EscapeMinigame.transStart = false;
            //StageController.buttonToReturnToCheckpoint = false;
            //}
        }
        transAnim.SetTrigger("transitionEnd");
        yield return new WaitForSeconds(0.5f);
        transEnd = true;
    }
}




