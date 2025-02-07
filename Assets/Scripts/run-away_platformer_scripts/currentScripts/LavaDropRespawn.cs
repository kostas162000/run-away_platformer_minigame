using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDropRespawn : MonoBehaviour
{
    private Rigidbody2D myrigidbody;
    private Vector2 startingposition;
    [SerializeField] private PlayerDeath playerdead;
    private bool hasFallen = false;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        startingposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerdead.death == true && hasFallen)
        {
            myrigidbody.bodyType = RigidbodyType2D.Static;
        }

        if (playerdead.death == false)
        {
            myrigidbody.bodyType = RigidbodyType2D.Dynamic;
            hasFallen = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LavaDropBottom")
        {
            transform.position = startingposition;
        }

        

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.position = startingposition;
            hasFallen = true;
        }

    }
}
