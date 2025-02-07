using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidBody; //intialize variable for rigid body
    [SerializeField] private GroundCollider ground; //get the object that is set at feet of player,
                                                    //so as to check if player has his feet on the ground
    public float jumpingDistance /*=17*/; //jumping ability of player
    public float speed /*=5*/; //speed of player
    public float poisonedspeed;
    public float poisonedjumping;
    private float tempS;
    private float tempJ;
    public bool ispoisoned = false;
    [SerializeField] private float poisonedTimer;
    [SerializeField] private int poisonedStatus = 0;
    private float tempT;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>(); //get rigid body of player 
        tempS = speed;
        tempJ = jumpingDistance;
        poisonedspeed = tempS / 1.5f;
        poisonedjumping = tempJ / 1.3f;
        tempT = poisonedTimer;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float Xaxis = Input.GetAxis("Horizontal") * speed; //initilize horizontal movement of player

        myRigidBody.velocity = new Vector2(Xaxis, myRigidBody.velocity.y); //horizontal movement of player


        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && ground.grounded == true)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpingDistance); //player jumps if he is on ground and proper keys are pressed
            ground.grounded = false; //when jumping, player is not on ground anymore, so he must not be able to jump again
            anim.SetBool("jump",true);
        }
        else anim.SetBool("jump", false);

        //code for player sprite to turn around
        if (Xaxis > 0.01f)
            transform.localScale = new Vector2(5f, 5f);
        else if (Xaxis < 0)
            transform.localScale = new Vector2(-5f, 5f);

        if (ispoisoned)
        {
            if (poisonedStatus < 2)
            {
                poisonedTimer -= Time.deltaTime;
                if (poisonedTimer <= 0.0f) //timer for player 
                {
                    speed = tempS;
                    jumpingDistance = tempJ;
                    poisonedTimer = tempT;
                    ispoisoned = false;
                }
            }
            else if (poisonedStatus >= 2)
            {
                speed = tempS;
                jumpingDistance = tempJ;
                poisonedTimer = tempT;
                poisonedStatus = 0;
                ispoisoned = false;
            }
        }
        anim.SetBool("run", Xaxis != 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sting")
        {
            ispoisoned = true;
            speed = poisonedspeed;
            jumpingDistance = poisonedjumping;
            poisonedStatus = poisonedStatus + 1;
        }

    }
}
