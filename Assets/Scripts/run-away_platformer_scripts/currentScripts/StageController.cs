using System.Collections;
using System.Collections.Generic;
using UnityEditor.Connect;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField] private GameObject Camera1;
    [SerializeField] private GameObject Camera2;
    [SerializeField] private GameObject Camera3;
    [SerializeField] private GameObject Camera4;
    [SerializeField] private GameObject Camera5;
    [SerializeField] private GameObject Camera6;
    [SerializeField] private GameObject Camera7;
    [SerializeField] private GameObject Camera8;
    [SerializeField] private GameObject Camera9;

    [SerializeField] private PlayerMovement Player1;
    [SerializeField] private EnemyScript Enemy1;
    [SerializeField] private PlayerMovement Player2;
    [SerializeField] private EnemyScript Enemy2;
    [SerializeField] private PlayerMovement Player3;
    [SerializeField] private EnemyScript Enemy3;
    [SerializeField] private PlayerMovement Player4;
    [SerializeField] private EnemyScript Enemy4;
    [SerializeField] private PlayerMovement Player5;
    [SerializeField] private EnemyScript Enemy5;
    [SerializeField] private PlayerMovement Player6;
    [SerializeField] private EnemyScript Enemy6;
    [SerializeField] private PlayerMovement Player7;
    [SerializeField] private EnemyScript Enemy7;
    [SerializeField] private PlayerMovement Player8;
    [SerializeField] private EnemyScript Enemy8;
    [SerializeField] private PlayerMovement Player9;
    [SerializeField] private EnemyScript Enemy9;

    [SerializeField] private int levelid;
    
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject permanentDieMenu;


    public static bool buttonToReturnToCheckpoint=false;
    public static int flagForRespawn = 0;

    private GameObject pivotCamera;

    //[SerializeField] private Animator anim;

    //private bool transitionTriggered = false;



    // Start is called before the first frame update
    void Start()
    {
        //trap = new TrapForMinigame();
    }

    // Update is called once per frame
    void Update()
    {

        //levelid = trap.assignedID;
        //levelid = TrapForMinigame.assignedID; //comment for testing, otherwise not testing

        //changeIDforTesting();

        if (TrapForMinigame.hasStepped == true)
        {
            levelid = TrapForMinigame.assignedID; //comment for testing, otherwise not testing 
            
        }

        if (levelid == 0)
        {
            Player1.enabled = false;
            Enemy1.enabled = false;
            Player2.enabled = false;
            Enemy2.enabled = false;
            Player3.enabled = false;
            Enemy3.enabled = false;

            Player4.enabled = false;
            Enemy4.enabled = false;
            Player5.enabled = false;
            Enemy5.enabled = false;
            Player6.enabled = false;
            Enemy6.enabled = false;

            Player7.enabled = false;
            Enemy7.enabled = false;
            Player8.enabled = false;
            Enemy8.enabled = false;
            Player9.enabled = false;
            Enemy9.enabled = false;


            Camera1.SetActive(false);
            Camera2.SetActive(false);
            Camera3.SetActive(false);
            Camera4.SetActive(false);
            Camera5.SetActive(false);
            Camera6.SetActive(false);
            Camera7.SetActive(false);
            Camera8.SetActive(false);
            Camera9.SetActive(false);

        }
        
        else
        {
            //TrapForMinigame.hasStepped = false;


            if (levelid == 1)
            {
                Camera1.SetActive(true);
                Player1.enabled = true;
                Enemy1.enabled = true;
                Camera2.SetActive(false);
                Player2.enabled = false;
                Enemy2.enabled = false;
                Camera3.SetActive(false);
                Player3.enabled = false;
                Enemy3.enabled = false;

                Camera4.SetActive(false);
                Player4.enabled = false;
                Enemy4.enabled = false;
                Camera5.SetActive(false);
                Player5.enabled = false;
                Enemy5.enabled = false;
                Camera6.SetActive(false);
                Player6.enabled = false;
                Enemy6.enabled = false;
                Camera7.SetActive(false);

                Player7.enabled = false;
                Enemy7.enabled = false;
                Camera8.SetActive(false);
                Player8.enabled = false;
                Enemy8.enabled = false;
                Camera9.SetActive(false);
                Player9.enabled = false;
                Enemy9.enabled = false;

                pivotCamera = Camera1;
            }
            else if (levelid == 2)
            {
                Camera1.SetActive(false);
                Player1.enabled = false;
                Enemy1.enabled = false;
                Camera2.SetActive(true);
                Player2.enabled = true;
                Enemy2.enabled = true;
                Camera3.SetActive(false);
                Player3.enabled = false;
                Enemy3.enabled = false;

                Camera4.SetActive(false);
                Player4.enabled = false;
                Enemy4.enabled = false;
                Camera5.SetActive(false);
                Player5.enabled = false;
                Enemy5.enabled = false;
                Camera6.SetActive(false);
                Player6.enabled = false;
                Enemy6.enabled = false;
                Camera7.SetActive(false);

                Player7.enabled = false;
                Enemy7.enabled = false;
                Camera8.SetActive(false);
                Player8.enabled = false;
                Enemy8.enabled = false;
                Camera9.SetActive(false);
                Player9.enabled = false;
                Enemy9.enabled = false;

                pivotCamera = Camera2;
            }

            else if (levelid == 3)
            {
                Camera1.SetActive(false);
                Player1.enabled = false;
                Enemy1.enabled = false;
                Camera2.SetActive(false);
                Player2.enabled = false;
                Enemy2.enabled = false;
                Camera3.SetActive(true);
                Player3.enabled = true;
                Enemy3.enabled = true;

                Camera4.SetActive(false);
                Player4.enabled = false;
                Enemy4.enabled = false;
                Camera5.SetActive(false);
                Player5.enabled = false;
                Enemy5.enabled = false;
                Camera6.SetActive(false);
                Player6.enabled = false;
                Enemy6.enabled = false;
                
                Camera7.SetActive(false);
                Player7.enabled = false;
                Enemy7.enabled = false;
                Camera8.SetActive(false);
                Player8.enabled = false;
                Enemy8.enabled = false;
                Camera9.SetActive(false);
                Player9.enabled = false;
                Enemy9.enabled = false;

                pivotCamera = Camera3;
            }

            else if (levelid == 4)
            {
                Camera1.SetActive(false);
                Player1.enabled = false;
                Enemy1.enabled = false;
                Camera2.SetActive(false);
                Player2.enabled = false;
                Enemy2.enabled = false;
                Camera3.SetActive(false);
                Player3.enabled = false;
                Enemy3.enabled = false;

                Camera4.SetActive(true);
                Player4.enabled = true;
                Enemy4.enabled = true;
                Camera5.SetActive(false);
                Player5.enabled = false;
                Enemy5.enabled = false;
                Camera6.SetActive(false);
                Player6.enabled = false;
                Enemy6.enabled = false;

                Camera7.SetActive(false);
                Player7.enabled = false;
                Enemy7.enabled = false;
                Camera8.SetActive(false);
                Player8.enabled = false;
                Enemy8.enabled = false;
                Camera9.SetActive(false);
                Player9.enabled = false;
                Enemy9.enabled = false;

                pivotCamera = Camera4;
            }

            else if (levelid == 5) 
            {
                Camera1.SetActive(false);
                Player1.enabled = false;
                Enemy1.enabled = false;
                Camera2.SetActive(false);
                Player2.enabled = false;
                Enemy2.enabled = false;
                Camera3.SetActive(false);
                Player3.enabled = false;
                Enemy3.enabled = false;

                Camera4.SetActive(false);
                Player4.enabled = false;
                Enemy4.enabled = false;
                Camera5.SetActive(true);
                Player5.enabled = true;
                Enemy5.enabled = true;
                Camera6.SetActive(false);
                Player6.enabled = false;
                Enemy6.enabled = false;

                Camera7.SetActive(false);
                Player7.enabled = false;
                Enemy7.enabled = false;
                Camera8.SetActive(false);
                Player8.enabled = false;
                Enemy8.enabled = false;
                Camera9.SetActive(false);
                Player9.enabled = false;
                Enemy9.enabled = false;

                pivotCamera = Camera5;
            }

            else if (levelid == 6) 
            {
                Camera1.SetActive(false);
                Player1.enabled = false;
                Enemy1.enabled = false;
                Camera2.SetActive(false);
                Player2.enabled = false;
                Enemy2.enabled = false;
                Camera3.SetActive(false);
                Player3.enabled = false;
                Enemy3.enabled = false;

                Camera4.SetActive(false);
                Player4.enabled = false;
                Enemy4.enabled = false;
                Camera5.SetActive(false);
                Player5.enabled = false;
                Enemy5.enabled = false;
                Camera6.SetActive(true);
                Player6.enabled = true;
                Enemy6.enabled = true;

                Camera7.SetActive(false);
                Player7.enabled = false;
                Enemy7.enabled = false;
                Camera8.SetActive(false);
                Player8.enabled = false;
                Enemy8.enabled = false;
                Camera9.SetActive(false);
                Player9.enabled = false;
                Enemy9.enabled = false;

                pivotCamera = Camera6;
            }
            
            else if (levelid == 7) 
            {
                Camera1.SetActive(false);
                Player1.enabled = false;
                Enemy1.enabled = false;
                Camera2.SetActive(false);
                Player2.enabled = false;
                Enemy2.enabled = false;
                Camera3.SetActive(false);
                Player3.enabled = false;
                Enemy3.enabled = false;

                Camera4.SetActive(false);
                Player4.enabled = false;
                Enemy4.enabled = false;
                Camera5.SetActive(false);
                Player5.enabled = false;
                Enemy5.enabled = false;
                Camera6.SetActive(false);
                Player6.enabled = false;
                Enemy6.enabled = false;

                Camera7.SetActive(true);
                Player7.enabled = true;
                Enemy7.enabled = true;
                Camera8.SetActive(false);
                Player8.enabled = false;
                Enemy8.enabled = false;
                Camera9.SetActive(false);
                Player9.enabled = false;
                Enemy9.enabled = false;

                pivotCamera = Camera7;
            }
            
            else if (levelid == 8) 
            {
                Camera1.SetActive(false);
                Player1.enabled = false;
                Enemy1.enabled = false;
                Camera2.SetActive(false);
                Player2.enabled = false;
                Enemy2.enabled = false;
                Camera3.SetActive(false);
                Player3.enabled = false;
                Enemy3.enabled = false;

                Camera4.SetActive(false);
                Player4.enabled = false;
                Enemy4.enabled = false;
                Camera5.SetActive(false);
                Player5.enabled = false;
                Enemy5.enabled = false;
                Camera6.SetActive(false);
                Player6.enabled = false;
                Enemy6.enabled = false;

                Camera7.SetActive(false);
                Player7.enabled = false;
                Enemy7.enabled = false;
                Camera8.SetActive(true);
                Player8.enabled = true;
                Enemy8.enabled = true;
                Camera9.SetActive(false);
                Player9.enabled = false;
                Enemy9.enabled = false;

                pivotCamera = Camera8;
            } 
            
            else if (levelid == 9) 
            {
                Camera1.SetActive(false);
                Player1.enabled = false;
                Enemy1.enabled = false;
                Camera2.SetActive(false);
                Player2.enabled = false;
                Enemy2.enabled = false;
                Camera3.SetActive(false);
                Player3.enabled = false;
                Enemy3.enabled = false;

                Camera4.SetActive(false);
                Player4.enabled = false;
                Enemy4.enabled = false;
                Camera5.SetActive(false);
                Player5.enabled = false;
                Enemy5.enabled = false;
                Camera6.SetActive(false);
                Player6.enabled = false;
                Enemy6.enabled = false;

                Camera7.SetActive(false);
                Player7.enabled = false;
                Enemy7.enabled = false;
                Camera8.SetActive(false);
                Player8.enabled = false;
                Enemy8.enabled = false;
                Camera9.SetActive(true);
                Player9.enabled = true;
                Enemy9.enabled = true;

                pivotCamera = Camera9;
            }
               
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 0;
                    //backgroundPanel.SetActive(true);
                    //pausePanel.SetActive(true);
                    pauseMenu.SetActive(true);
                    Cursor.visible = true;
                }

                /*if (Input.GetKeyDown(KeyCode.Return))
                {
                    Time.timeScale = 1;
                    //backgroundPanel.SetActive(false);
                    //pausePanel.SetActive(false);
                }*/
        }


        
        //if (PlayerDeath.playerEscaped)
        if (flagForRespawn == 4)
            exitMinigame();
        /*Debug.Log("id:" + levelid);
        Debug.Log("player escaped:" + PlayerDeath.playerEscaped);
        Debug.Log("trans start:" + PlayerDeath.transStart);
        Debug.Log("trans end:" + PlayerDeath.transEnd);*/
    }

    public void Resume()
    {
        Time.timeScale = 1;
        //Debug.Log("Resume method was called!");
        //backgroundPanel.SetActive(false);
        //pausePanel.SetActive(false);
        pauseMenu.SetActive(false);
        Cursor.visible = false;
    }
    /*IEnumerator transitionAnimation()
    {
        anim.SetTrigger("transitionStart");
        yield return new WaitForSeconds(1);
        anim.SetTrigger("transitionEnd");
        yield return new WaitForSeconds(1);
        transitionTriggered = true;
        TrapForMinigame.hasStepped = false;

        
    }*/


    public void returnToCheckpoint()
    {
        TrapForMinigame.hasStepped = false;
        permanentDieMenu.SetActive(false);
        pivotCamera.SetActive(false);
        levelid = 0;
        buttonToReturnToCheckpoint = true;
        //flagForRespawn = 0;
        Cursor.visible = false;
    }

    
    private void exitMinigame()
    {
        TrapForMinigame.hasStepped = false;
        if (playerReturnsFromMinigame.cameraActivated)
        {
            pivotCamera.SetActive(false);
            playerReturnsFromMinigame.cameraActivated = false;
        }
        //if(flagForRespawn == 4)
        levelid = 0;
        flagForRespawn = 0;
        //PlayerDeath.playerEscaped = false;
    }


    void changeIDforTesting() 
    {
        //Debug.Log(levelid);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            levelid = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            levelid = 2;
            flagForRespawn = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            levelid = 3;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            levelid = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            levelid = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            levelid = 6;
            //flagForRespawn = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            levelid = 7;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            levelid = 8;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            levelid = 9;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            levelid = 0;
        }
    }


    /*public void testForReset()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }*/
}
