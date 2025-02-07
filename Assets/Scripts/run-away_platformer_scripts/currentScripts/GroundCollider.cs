using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    [SerializeField] private float muddyspeed; //speed when in mud
    [SerializeField] private float muddyjumping; //jumping when in mud
    public bool grounded; //state of touching the ground or not
    [SerializeField] private PlayerMovement player; //get player to see if he triggers trap
    private float tempS;
    private float tempJ;


    // Start is called before the first frame update
    void Start()
    {
        tempS = player.speed;
        tempJ = player.jumpingDistance;
        muddyspeed = tempS/1.67f; 
        muddyjumping = tempJ / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") //if player is on ground and not on mud,
                                                  // speed and jumping ability return to starting values
        {
            grounded = true; //set state on ground
            if (player.ispoisoned == false)
            {
                player.speed = tempS;
                player.jumpingDistance = tempJ;
            }
            else
            {
                player.speed = player.poisonedspeed;
                player.jumpingDistance = player.poisonedjumping;
            }
  
        }
        else if (collision.gameObject.tag == "MuddyGround") //if player is on ground and on mud,
                                                            // speed and jumping ability are reduced
        {

            grounded = true; //set state on ground
            if (player.ispoisoned == false)
            {
                player.speed = muddyspeed;
                player.jumpingDistance = muddyjumping;
            }
            else
            {
                player.speed = player.poisonedspeed;
                player.jumpingDistance = player.poisonedjumping;
            }
        }
    }
}
