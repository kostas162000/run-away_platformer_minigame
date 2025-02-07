using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStalagmitesController : MonoBehaviour
{
    private Vector2 startingposition; //starting position of stalagmites
    [SerializeField] private PlayerDeath playerdead; //get player that dies when being hit buy stalagmites
    [SerializeField] private FallingStalgmitesTrap stalagmiteTrap; //get trigger of stalagmites
    [SerializeField] private float timer;
    [SerializeField] private bool playerIsDead=false;
    private Rigidbody2D myRigidBody; //intialize variable for rigid body
    private float temp;

    //[SerializeField] private float timerForStalagmite=0.5f;

    // Start is called before the first frame update
    void Start()
    {
        temp = timer;
        myRigidBody = GetComponent<Rigidbody2D>(); //get rigid body of stalagmites
        startingposition = transform.position; //initialize starting position
    }

    // Update is called once per frame
    void Update()
    {
        if (playerdead.death == true)
        {
            playerIsDead = true;
        }
        Respawn();

    }


    void Respawn()
    {
        if (playerIsDead)
        {

            if (stalagmiteTrap.stHasfallen == true && stalagmiteTrap.stToRespawn == true)
            {
                myRigidBody.bodyType = RigidbodyType2D.Static; //set type of stalgmites to static, so as to not fall before player triggers them
                transform.position = startingposition; //stalagmites go back to starting position
                stalagmiteTrap.stHasfallen = false; //state of stalagmites is set to not fallen
                stalagmiteTrap.stToRespawn = false;
                timer = temp; //timer return to orignal value
                playerIsDead = false;
            }

        }

        if(StageController.flagForRespawn == 3)
        {
            myRigidBody.bodyType = RigidbodyType2D.Static; //set type of stalgmites to static, so as to not fall before player triggers them
            transform.position = startingposition; //stalagmites go back to starting position
            stalagmiteTrap.stHasfallen = false; //state of stalagmites is set to not fallen
            stalagmiteTrap.stToRespawn = false;
            timer = temp; //timer return to orignal value
            playerIsDead = false;
            StageController.flagForRespawn = 4;
        }
    }

    /*void Respawn()
    {
        

            if (playerdead.stalagmiteToRespawn)
            {
                myRigidBody.bodyType = RigidbodyType2D.Static; //set type of stalgmites to static, so as to not fall before player triggers them
                transform.position = startingposition; //stalagmites go back to starting position

            timerForStalagmite -= Time.deltaTime; //when platform has fallen timer starts in order for it to respawn 
            if (timerForStalagmite <= 0.0f)
            {
                playerdead.stalagmiteToRespawn = false;
                timerForStalagmite = 0.5f;
            }
            //stalagmiteTrap.stHasfallen = false; //state of stalagmites is set to not fallen
            //stalagmiteTrap.stToRespawn = false;
            //timer = temp; //timer return to orignal value
            //playerIsDead = false;
        }

        
    }*/
}
