using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOutcome : MonoBehaviour
{
    [SerializeField] private PlayerHealth player;

    [SerializeField] private EnemyHealth enemy1;
    [SerializeField] private EnemyHealth enemy2;
    [SerializeField] private EnemyHealth enemy3;
    [SerializeField] private EnemyHealth enemy4;
    [SerializeField] private EnemyHealth enemy5;


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
            SceneController.playerWon = true;
        }

        if(PlayerHealth.playerLost)
        {
            player.currentHealth = player.maxHealth;

            enemy1.currentHealth = enemy1.maxHealth;
            enemy2.currentHealth = enemy2.maxHealth;
            enemy3.currentHealth = enemy3.maxHealth;
            enemy4.currentHealth = enemy4.maxHealth;
            enemy5.currentHealth = enemy5.maxHealth;
        }
    }
}
