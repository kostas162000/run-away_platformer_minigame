using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingDisable : MonoBehaviour
{
    private GameObject sting; //= this.GameOnject;
    // Start is called before the first frame update
    void Start()
    {
        sting  = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sting.SetActive(false);
        }
    }
}
