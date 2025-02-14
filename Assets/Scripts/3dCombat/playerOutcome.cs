using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerOutcome : MonoBehaviour
{
    [SerializeField] private PlayerHealth player;

    [SerializeField] private EnemyHealth enemy1;
    [SerializeField] private EnemyHealth enemy2;
    [SerializeField] private EnemyHealth enemy3;
    [SerializeField] private EnemyHealth enemy4;
    [SerializeField] private EnemyHealth enemy5;

    [SerializeField] private floatingHealthBar bar1;
    [SerializeField] private floatingHealthBar bar2;
    [SerializeField] private floatingHealthBar bar3;
    [SerializeField] private floatingHealthBar bar4;
    [SerializeField] private floatingHealthBar bar5;


    [SerializeField] private Animator transAnim;

    public static bool restartDeadEnemies = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy1.enemyDefeated == true && enemy2.enemyDefeated == true && enemy3.enemyDefeated == true && 
            enemy4.enemyDefeated == true && enemy5.enemyDefeated == true)
        {
            //SceneController.playerWon = true;
            StartCoroutine(transitionAnimation());
        }

        if(PlayerHealth.playerLost)
        {
            player.currentHealth = player.maxHealth;

            enemy1.currentHealth = enemy1.maxHealth;
            enemy2.currentHealth = enemy2.maxHealth;
            enemy3.currentHealth = enemy3.maxHealth;
            enemy4.currentHealth = enemy4.maxHealth;
            enemy5.currentHealth = enemy5.maxHealth;

            //StartCoroutine(transitionAnimationLost());
        }

        Debug.Log(enemy1.enemyDefeated);


        if (restartDeadEnemies == true)
        {
            enemy1.GetComponent<NavMeshAgent>().enabled = true;
            enemy1.GetComponent<EnemyAI>().enabled = true;
            enemy1.currentHealth = enemy1.maxHealth;
            bar1.slider.value = 1;

            enemy2.GetComponent<NavMeshAgent>().enabled = true;
            enemy2.GetComponent<EnemyAI>().enabled = true;
            enemy2.currentHealth = enemy2.maxHealth;
            bar2.slider.value = 1;

            enemy3.GetComponent<NavMeshAgent>().enabled = true;
            enemy3.GetComponent<EnemyAI>().enabled = true;
            enemy3.currentHealth = enemy3.maxHealth;
            bar3.slider.value = 1;

            enemy4.GetComponent<NavMeshAgent>().enabled = true;
            enemy4.GetComponent<EnemyAI>().enabled = true;
            enemy4.currentHealth = enemy4.maxHealth;
            bar4.slider.value = 1;

            enemy5.GetComponent<NavMeshAgent>().enabled = true;
            enemy5.GetComponent<EnemyAI>().enabled = true;
            enemy5.currentHealth = enemy5.maxHealth;
            bar5.slider.value = 1;

            restartDeadEnemies = false;
        }
    }



    private IEnumerator transitionAnimation()
    {
        transAnim.SetTrigger("transitionStart");
        yield return new WaitForSeconds(1.5f);

        SceneController.playerWon = true;
        
        transAnim.SetTrigger("transitionEnd");
        //yield return new WaitForSeconds(0.5f);

        enemy1.enemyDefeated = false;
        enemy2.enemyDefeated = false;
        enemy3.enemyDefeated = false;
        enemy4.enemyDefeated = false;
        enemy5.enemyDefeated = false;
        
    }

    
}
