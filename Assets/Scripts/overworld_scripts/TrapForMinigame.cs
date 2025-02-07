using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapForMinigame : MonoBehaviour
{
    public static int assignedID = 0;
    private int min = 1;
    private int max = 3;
    public static bool hasStepped = false;
    [SerializeField] private int difficultyOffset;

    [SerializeField] private GameObject hole;
    [SerializeField] private GameObject CameraFromMainGame;
    [SerializeField] private playerTestMovement MainPlayer;
   

    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //playerReturnsToMainGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(transitionAnimation());
            hole.SetActive(true);
        }

    }

    

   

    private IEnumerator transitionAnimation()
    {
        MainPlayer.enabled = false;
        anim.SetTrigger("transitionStart");
        yield return new WaitForSeconds(1.5f);
        StageController.flagForRespawn = 0;
        CameraFromMainGame.SetActive(false);
        hasStepped = true;
        anim.SetTrigger("transitionEnd");
        yield return new WaitForSeconds(0.3f);
        assignedID = UnityEngine.Random.Range(min, max + 1) + difficultyOffset;
        hole.SetActive(false);
    }

}
