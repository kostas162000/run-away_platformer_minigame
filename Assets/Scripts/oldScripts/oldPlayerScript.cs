using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private BoxCollider2D box;
    [SerializeField] private  float jumpingDistance;
    [SerializeField] private float speed;
    private float muddyspeed;
    private float muddyjumping;
    private bool grounded;
    private bool hasTouchedMud;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float Xaxis = Input.GetAxis("Horizontal") * speed;
        //float Yaxis = Input.GetAxis("Vertical") * jump;
        //transform.Translate(Xaxis * Time.deltaTime , 0, 0);
        myRigidBody.velocity = new Vector2(Xaxis, myRigidBody.velocity.y);

        /*Vector3 max = box.bounds.max;
        Vector3 min = box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, (min.y - 0.1f));
        Vector2 corner2 = new Vector2(min.x, (min.y - 0.1f));
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        grounded = false;
        if (hit != null)
        {
            grounded = true;
        }*/
         

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && grounded)
        {
            Jump();
            //myRigidBody.AddForce(Vector2.up *jumpingDistance, ForceMode2D.Impulse);
        }

        if (Xaxis > 0.01f)
            transform.localScale = new Vector2(1.5f, 1.5f);
        else if (Xaxis < 0)
            transform.localScale = new Vector2(-1.5f, 1.5f);

        //}
    }


    private void Jump()
    {
        //myRigidBody.velocity = Vector2.up * jumpingDistance;
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpingDistance);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        muddyspeed = speed / 1.67f;
        muddyjumping = jumpingDistance / 2;
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            if (hasTouchedMud == false)
            {
                speed = muddyspeed * 1.67f;
                jumpingDistance = muddyjumping * 2;
            }
            else if (hasTouchedMud == true)
            {
                hasTouchedMud = false;
                speed = speed * 1.67f;
                jumpingDistance = jumpingDistance * 2;
            }
        }
        else if (collision.gameObject.tag == "MuddyGround")
        {
            grounded = true;
            if (hasTouchedMud == false)
            {
                hasTouchedMud = true;
                speed = muddyspeed;
                jumpingDistance = muddyjumping;
            }
            else if(hasTouchedMud == true)
            {
                speed = muddyspeed * 1.67f;
                jumpingDistance = muddyjumping * 2;
            }
        }
    }
}
