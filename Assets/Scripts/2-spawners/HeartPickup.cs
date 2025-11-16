using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public float fallSpeed = 1f; // slower drop than enemies
    public int healAmount = 1;

    void Update()
    {
        // simple falling movement
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();

            // Add health only if player is NOT full
            if (player != null && player.currentHealth < player.maxHealth)
            {
                player.AddHealth(healAmount);
            }

            Destroy(gameObject); // disappear after touching
        }
    }
}