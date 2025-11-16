using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Awake()
    {
        // Get PlayerHealth component from the same object
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only react to enemies
        if (other.CompareTag("Enemy"))
        {
            if (playerHealth != null)
            {
                // Remove 1 heart
                playerHealth.TakeDamage(1);
            }
        }
    }
}