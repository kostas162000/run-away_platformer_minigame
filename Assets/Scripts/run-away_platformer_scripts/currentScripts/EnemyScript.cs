using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject player; //get player to follow
    [SerializeField] private float speed /*=4*/; //speed of enemy
    private Vector2 startingposition; //starting position for respawn
    [SerializeField] private float timer;
    [SerializeField] private PlayerDeath playerdead; //get player, to respawn enemy when player dead
    private bool enemyRespawned;
    private float temp;
    private float tmp;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        tmp =  speed;
        temp = timer;
        startingposition = transform.position; //initialize starting position
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position,
        speed * Time.deltaTime); //enemy follows player

        if (playerdead.death == true)
        {
            speed = 0; // when player dies enemy stops
            enemyRespawned = false;
        }
        Respawn();

        if (PlayerDeath.playerEscaped == true) 
            speed = 0;
    }

    void Respawn()
    {
        if (playerdead.playerRespawned == true && enemyRespawned == false)
        {
            timer -= Time.deltaTime; //when player respawns timer starts for enemy to respawn in order ro give advantage to player
            if (timer <= 0.0f)
            {
                transform.position = startingposition; //enemy goes back to starting position
                anim.SetBool("EnemyAttack", false);
                speed = tmp; //speed and timer
                timer = temp; //return to orignal values
                enemyRespawned = true;
                //playerdead.isdead = false; //player is now alive
            }
        }

        if(StageController.flagForRespawn == 1)
        {
            transform.position = startingposition; //enemy goes back to starting position
            anim.SetBool("EnemyAttack", false);
            speed = tmp; //speed and timer
            StageController.flagForRespawn = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("EnemyAttack", true);
            //anim.SetTrigger("EnemyAttack");
        }
    }
}
