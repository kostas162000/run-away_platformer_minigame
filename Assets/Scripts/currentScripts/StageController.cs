using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private GameObject Camera1;
    [SerializeField] private GameObject Camera2;
    [SerializeField] private PlayerMovement Player1;
    [SerializeField] private EnemyScript Enemy1;
    [SerializeField] private PlayerMovement Player2;
    [SerializeField] private EnemyScript Enemy2;
    [SerializeField] private int id;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            id = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            id = 2;
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            id = 0;
        }

        if (id == 1)
        {
            Camera1.SetActive(true);
            Player1.enabled = true;
            Enemy1.enabled = true;
            Camera2.SetActive(false);
            Player2.enabled = false;
            Enemy2.enabled = false;
        }
        else if (id == 2)
        {
            Camera1.SetActive(false);
            Player1.enabled = false;
            Enemy1.enabled = false;
            Camera2.SetActive(true);
            Player2.enabled = true;
            Enemy2.enabled = true;
        }
        else
        {
            Player1.enabled = false;
            Enemy1.enabled = false;
            Player2.enabled = false;
            Enemy2.enabled = false;
        }
    }
}
