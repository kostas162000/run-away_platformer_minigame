using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransport : MonoBehaviour
{
    //[SerializeField] private Transform outsideCave;
    [SerializeField] private Transform insideCave;
    [SerializeField] private GameObject Player;
    //[SerializeField] private Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.position = insideCave.transform.position;
            //RB.MovePosition(insideCave.transform.position);
            //Player.transform.position = new Vector3(-31.97f, 29.67f, -1);
        }

    }

}
