using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 10; // The amount of damage this enemy inflicts

    // This method assumes the enemy has a collider and the player has the "Player" tag.
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is tagged as "Player"
        /*if (collision.gameObject.CompareTag("Player"))
        {
            // Try to get the PlayerHealth component from the player
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }*/




        /*if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player is being fucking hit ");
            // Try to get the PlayerHealth component from the player
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }*/
    }

    // If you prefer trigger-based detection, use the following instead:
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("player is being hit ");
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
    
}
