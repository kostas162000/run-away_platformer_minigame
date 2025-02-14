using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject topDownCamera;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;
    [SerializeField] private GameObject enemy4;
    [SerializeField] private GameObject enemy5;

    [SerializeField] private int levelid;

    public static bool playerWon = false;


    private Vector3 playerPosition;
    private Vector3 enemy1Position;
    private Vector3 enemy2Position;
    private Vector3 enemy3Position;
    private Vector3 enemy4Position;
    private Vector3 enemy5Position;

    
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = player.transform.position;

        enemy1Position = enemy1.transform.position;
        enemy2Position = enemy2.transform.position;
        enemy3Position = enemy3.transform.position;
        enemy4Position = enemy4.transform.position;
        enemy5Position = enemy5.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (BanditMovementEvent.combatTriggered) 
        { 
            levelid = BanditMovementEvent.sceneID;
            //playerWon = false;
            //BanditMovementEvent.combatTriggered = false;
        }

        if(levelid == 0)
        {
            //topDownCamera.SetActive(true);


            player.SetActive(false);

            enemy1.SetActive(false);
            enemy2.SetActive(false);
            enemy3.SetActive(false);
            enemy4.SetActive(false);
            enemy5.SetActive(false);
        }

        if (levelid == 1)
        {
            player.SetActive(true);

            enemy1.SetActive(true);
            enemy2.SetActive(true);
            enemy3.SetActive(true);
            enemy4.SetActive(true);
            enemy5.SetActive(true);

            //restartDeadEnemoies = true;
            
        }


        if (playerWon)
        {
            levelid = 0;
            player.SetActive(false);

            enemy1.SetActive(false);
            enemy2.SetActive(false);
            enemy3.SetActive(false);
            enemy4.SetActive(false);
            enemy5.SetActive(false);
        }

        if (PlayerHealth.playerLost == true)
        {
            levelid = 0;
            player.SetActive(false);

            enemy1.SetActive(false);
            enemy2.SetActive(false);
            enemy3.SetActive(false);
            enemy4.SetActive(false);
            enemy5.SetActive(false);

            player.transform.position = playerPosition;

            enemy1.transform.position = enemy1Position;
            enemy2.transform.position = enemy2Position;
            enemy3.transform.position = enemy3Position;
            enemy4.transform.position = enemy4Position;
            enemy5.transform.position = enemy5Position;
        }

        
    }
}
