using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public bool death; //state of player (dead or alive)
    [SerializeField] private int deathcount = 0; //counter for deaths
    [SerializeField] private float timer;
    private Vector2 startingposition; //starting position of player for respawn
    public bool playerRespawned; //check if player respawned for other scripts
    private float temp;
    [SerializeField] private int poisonedStatus=0;
    

    // Start is called before the first frame update
    void Start()
    {
        temp = timer;
        startingposition = transform.position; //initialize starting position
    }

    // Update is called once per frame
    void Update()
    {
        if (death == true)
        {
            GetComponent<PlayerMovement>().enabled = false; //when player dies movement script gets disabled, so player cannot move
            playerRespawned = false; //set state as not respawned
            if (deathcount < 3) //player can respawn 3 times
            {
                Respawn();
            }
        }
        else if (death == false)
        {
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
        else if (collision.gameObject.tag == "ScorpionSting")
        {
            poisonedStatus = poisonedStatus + 1;
            if (poisonedStatus >= 2)
            {
                death = true;
                poisonedStatus = 0;
            }
        }
    }

    void Respawn()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f) //timer for player to respawn 
        {
            transform.position = startingposition; //player goes back to starting position
            deathcount++; //number of deaths rises
            timer = temp; //timer return to orignal value
            death = false; //state of plyaer is set to alive
            playerRespawned = true; //player is now respawned
            poisonedStatus = 0;
        }

        
    }


    
}




