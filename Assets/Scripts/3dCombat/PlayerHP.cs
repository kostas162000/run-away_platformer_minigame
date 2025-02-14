using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For scene reloading if needed


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;         // Maximum health of the player
    public int currentHealth;           // Current health value
    public int extraLives = 2;          // Number of respawns allowed

    private Vector3 spawnPosition;      // Where the player will respawn

    [SerializeField] private Animator transAnim;

    public static bool playerLost;

    public Text healthText; // Drag your Text UI element here in the Inspector
    void Start()
    {
        // Initialize current health and record the starting spawn position.
        currentHealth = maxHealth;
        spawnPosition = transform.position;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            
            StartCoroutine(transitionAnimation());
            //Respawn();
            //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
            //BanditMovementEvent.sceneID = 0;
            currentHealth = maxHealth;
        }

        UpdateHealthUI();
    }

    // Call this method when the player takes damage.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took " + damage + " damage. Current health: " + currentHealth);

        UpdateHealthUI();
    }

    // Respawn the player if extra lives remain; otherwise, end the game.
    void Respawn()
    {
        if (extraLives > 0)
        {
            extraLives--;
            currentHealth = maxHealth;
            transform.position = spawnPosition;
            Debug.Log("Player respawned. Extra lives left: " + extraLives);
            // Optionally, reset player velocity, play an animation, etc.
        }
        else
        {
            Debug.Log("Game Over!");
            // Optionally, reload the scene:
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    private IEnumerator transitionAnimation()
    {
        transAnim.SetTrigger("transitionStart");
        yield return new WaitForSeconds(1.5f);

        playerLost = true;
        

        transAnim.SetTrigger("transitionEnd");
        //yield return new WaitForSeconds(0.5f);
        
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }
}
