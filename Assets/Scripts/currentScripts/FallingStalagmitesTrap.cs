using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStalgmitesTrap : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidBody; //get the rigid body of stalagmites
    [SerializeField] public bool stHasfallen=false; //state of stalagmites (fallen or not)
    [SerializeField] public bool stToRespawn;
    [SerializeField] private float timer;
    private float temp;

    // Start is called before the first frame update
    void Start()
    {
        temp = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if(stHasfallen == true && stToRespawn == false)
        {
            RespawnST();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myRigidBody.bodyType = RigidbodyType2D.Dynamic; //when player triggers trap the stalagmites' type
                                                            //beacomes dynamic for the stalgmites to fall
            myRigidBody.mass = 1;          //set value of
            myRigidBody.gravityScale = 10; //mass and gravity
            stHasfallen = true; //state of stalagmites is fallen
        }
    }

    void RespawnST()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f) //timer for 
        {
            stToRespawn = true;
            timer = temp;
        }
    }
}
