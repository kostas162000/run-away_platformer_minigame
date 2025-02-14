using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionStingController : MonoBehaviour
{
    [SerializeField] private GameObject sting;
    
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
        if (sting.activeSelf == false)
        {
            //sting.SetActive(false);
            timer -= Time.deltaTime;
            if (timer <= 0.0f) //timer for player to respawn 
            {
                sting.SetActive(true);
                timer = temp;
                
            }
            }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //playerStung = true;
        }
    }
}
