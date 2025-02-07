using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerReturnsFromMinigame : MonoBehaviour
{
    [SerializeField] private GameObject CameraFromMainGame;
    [SerializeField] private playerTestMovement MainPlayer;

    [SerializeField] private GameObject playerToMoveToSetPoint;
    [SerializeField] private Transform caveGoTo;

    [SerializeField] private Animator anim;
    public static bool cameraActivated = false;

    private float timer = 10f;
    private float temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = timer;
    }

    // Update is called once per frame
    void Update()
    {
        playerReturnsToMainGame();
        //Debug.Log("Transition starts" + PlayerDeath.transStart);
        //Debug.Log(StageController.flagForRespawn);
        //Debug.Log("Player escaped" + PlayerDeath.playerEscaped);*/
    }

    private void playerReturnsToMainGame()
    {
        if (StageController.buttonToReturnToCheckpoint)
        {
            playerToMoveToSetPoint.transform.position = SetRespawnPoint.RespawnPoint;
            CameraFromMainGame.SetActive(true);
            MainPlayer.enabled = true;
            StageController.buttonToReturnToCheckpoint = false;
        }

        if (PlayerDeath.playerEscaped)
        {
            //StartCoroutine(transitionAnimationBackwards());
            transitionAnimation();

        }
    }

    /*private IEnumerator transitionAnimationBackwards()
    {
        anim.SetTrigger("transitionStart");
        playerToMoveToSetPoint.transform.position = caveGoTo.transform.position;
        //anim.SetTrigger("transitionStart");
        yield return new WaitForSeconds(1.5f);
        CameraFromMainGame.SetActive(true);
        cameraActivated = true;
        anim.SetTrigger("transitionEnd");
        yield return new WaitForSeconds(0.3f);
        MainPlayer.enabled = true;
        PlayerDeath.playerEscaped = false;
    }*/

    private void transitionAnimation()
    {
        if (PlayerDeath.transStart)
        {
            playerToMoveToSetPoint.transform.position = caveGoTo.transform.position;
            CameraFromMainGame.SetActive(true);

            MainPlayer.enabled = true;
            if (PlayerDeath.transEnd)
            {
                cameraActivated = true;
                
                /*timer -= Time.deltaTime;
                if (timer <= 0.0f)
                {
                    timer = temp;*/

                    PlayerDeath.transStart = false;
                    PlayerDeath.transEnd = false;
                    PlayerDeath.playerEscaped = false;
                //}
            }
        }
    }
}
