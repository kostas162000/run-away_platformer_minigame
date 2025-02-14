using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BanditMovementEvent : MonoBehaviour
{
    [SerializeField] private GameObject CameraFromMainGame;
    [SerializeField] private GameObject mainPlayer;
    [SerializeField] private playerTestMovement playerMovement;
    private float speed = 4;
    [SerializeField] private BanditTriggerEvent trigger;

    //[SerializeField] private GameObject mainScene;

    public static int sceneID;
    public static bool combatTriggered = false;

    [SerializeField] private int fightID; //1 for forrest, 2 for cave;


    [SerializeField] private Animator anim;

    
    private Vector2 startingPosition;

    private bool playerNeedsToRespawn = false;

    // Start is called before the first frame update
    void Start()
    {
        fightID = 1; //for now only forrest
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.playerSeen)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, mainPlayer.transform.position,
            speed * Time.deltaTime);
            playerMovement.enabled = false;
        }


        if(SceneController.playerWon)
        {
            sceneID = 0;
            CameraFromMainGame.SetActive(true);
            playerMovement.enabled = true;
            Destroy(this.gameObject);
            //SceneController.playerWon = false;
            combatTriggered = false;
        }

        if (PlayerHealth.playerLost && playerNeedsToRespawn == true)
        {
            sceneID = 0;
            CameraFromMainGame.SetActive(true);
            playerMovement.enabled = true;
            transform.position = startingPosition;
            mainPlayer.transform.position = SetRespawnPoint.RespawnPoint;
            playerNeedsToRespawn = false;
            combatTriggered = false;
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerOutcome.restartDeadEnemies = true;
            SceneController.playerWon = false;
            PlayerHealth.playerLost = false;
            StartCoroutine(transitionAnimation());
        }

    }


    /*private IEnumerator destroyBandit()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);
    }*/


    private IEnumerator transitionAnimation()
    {
        trigger.playerSeen = false;
        //playerMovement.enabled = true;
        anim.SetTrigger("transitionStart");
        yield return new WaitForSeconds(1.5f);
        //StageController.flagForRespawn = 0;
        CameraFromMainGame.SetActive(false);
        combatTriggered = true;
        anim.SetTrigger("transitionEnd");
        yield return new WaitForSeconds(0.3f);
        sceneID = fightID;
        //hole.SetActive(false);
        playerNeedsToRespawn = true;
    }

   
}
