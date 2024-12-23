using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class GroundCollider : MonoBehaviour
{
    /*public float muddyspeed; //speed when in mud
    public float muddyjumping; //jumping when in mud
    public bool grounded; //state of touching the ground or not
    public bool hasTouchedMud; // state of being in mud or not
    [SerializeField] private PlayerMovement player; //get player to see if he triggers trap
    private float tempS;
    private float tempJ;

    // Start is called before the first frame update
    void Start()
    {
        tempS = player.speed;
        tempJ = player.jumpingDistance;
        muddyspeed = tempS / 1.67f;
        muddyjumping = tempJ / 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        muddyspeed = player.speed / 1.67f;          //speed and jumping ability
        muddyjumping = player.jumpingDistance / 2;  //shorten when touching mud

        if (collision.gameObject.tag == "Ground") //if player is on ground and not on mud,
                                                  // speed and jumping ability return to starting values
        {
            grounded = true; //set state on ground
            if (hasTouchedMud == false) 
            {
                player.speed = muddyspeed * 1.67f;
                player.jumpingDistance = muddyjumping * 2;
            }
            else if (hasTouchedMud == true)
            {
                hasTouchedMud = false; //if player was previously on mud, state returns to not on mud
                player.speed = player.speed * 1.67f;
                player.jumpingDistance = player.jumpingDistance * 2;
            }
        }
        else if (collision.gameObject.tag == "MuddyGround") //if player is on ground and on mud,
                                                            // speed and jumping ability are reduced
        {

            grounded = true; //set state on ground
            if (hasTouchedMud == false)
            {
                hasTouchedMud = true; //if player was previously not on mud, state returns to on mud
                player.speed = muddyspeed; //set speed to speed on mud
                player.jumpingDistance = muddyjumping; //set jumping ability to jumping ability on mud
            }
            else if (hasTouchedMud == true)
            {
                player.speed = muddyspeed * 1.67f;          //if player was already on mud speed and jumping ability
                player.jumpingDistance = muddyjumping * 2;  //are increased so that they remain in the same values
            }
        }
    }
}*/
