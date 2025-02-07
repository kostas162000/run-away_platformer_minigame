using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditMovementEvent : MonoBehaviour
{
    [SerializeField] private GameObject mainPlayer;
    private float speed = 4;
    [SerializeField] private BanditTriggerEvent trigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.playerSeen)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, mainPlayer.transform.position,
            speed * Time.deltaTime);
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            trigger.playerSeen = false;
        }

    }


}
