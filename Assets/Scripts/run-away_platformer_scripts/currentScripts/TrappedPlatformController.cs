using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrappedPlatformController : MonoBehaviour
{
    private Rigidbody2D myrigidbody; //intialize variable for rigid body
    private Vector2 startingposition; //starting position for respawn
    [SerializeField] private PlayerDeath playerdead; //get player, to respawn platform when player dead
    [SerializeField] private float timer;
    private bool hasfallen = false; //state of trapped platform (fallen or not)
    private float temp;


    // Start is called before the first frame update
    void Start()
    {
        temp = timer;
        myrigidbody = GetComponent<Rigidbody2D>(); //get rigid body of platform
        startingposition = transform.position; //initialize starting position
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody.bodyType = RigidbodyType2D.Static;
        if (playerdead.death == true)
        {
             Respawn();
        }
        }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myrigidbody.bodyType = RigidbodyType2D.Dynamic; //when player collides with platform its type becomes dynamic in order to fall
            hasfallen = true; //state of platform is set to fallen
        }
    }

    void Respawn()
    {
       

        if (hasfallen == true)
        {
            timer -= Time.deltaTime; //when platform has fallen timer starts in order for it to respawn 
            if (timer <= 0.0f)
            {
                myrigidbody.bodyType = RigidbodyType2D.Static; //type of platofrm is set to static, so as to not fall before player collied with it
                transform.position = startingposition; //platform goes back to starting position
                hasfallen = false; //state of platform is set to not fallen
                timer = temp; //timer return to orignal value
                //playerdead.isdead = false; //set of player is set to alive
            }

        }


    }
}
