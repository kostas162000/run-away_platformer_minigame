using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;

    public bool enemyDefeated;

    [SerializeField] floatingHealthBar healthBar;


    private void Awake()
    {
        healthBar = GetComponentInChildren<floatingHealthBar>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }


    void Update()
    {
        

        if(PlayerHealth.playerLost)
        {
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<EnemyAI>().enabled = true;
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Debug.Log(gameObject.name + " took " + damage + " damage! Remaining health: " + currentHealth);
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " has been defeated!");
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        //Destroy(gameObject); // Remove the enemy from the scene
        transform.rotation = Quaternion.Euler(-90f, transform.eulerAngles.y, transform.eulerAngles.z);
        enemyDefeated = true;
        //currentHealth = maxHealth;
    }
}
