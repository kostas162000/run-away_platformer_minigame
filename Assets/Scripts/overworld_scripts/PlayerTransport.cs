using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransport : MonoBehaviour
{
    //[SerializeField] private Transform outsideCave;
    [SerializeField] private Transform insideCave;
    [SerializeField] private GameObject Player;
    [SerializeField] private playerTestMovement playerMovement;

    
    //[SerializeField] private Rigidbody2D RB;
    // Start is called before the first frame update

    [SerializeField] private Animator anim;
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
            playerMovement.enabled = false;
            StartCoroutine(transitionAnimation());
            //RB.MovePosition(insideCave.transform.position);
            //Player.transform.position = new Vector3(-31.97f, 29.67f, -1);
        }

    }


    private IEnumerator transitionAnimation()
    {
        anim.SetTrigger("transitionStart");
        yield return new WaitForSeconds(1.5f);
        Player.transform.position = insideCave.transform.position;
        anim.SetTrigger("transitionEnd");
        yield return new WaitForSeconds(0.5f);
        playerMovement.enabled = true;
    }
    }
