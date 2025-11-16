using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public Image[] heartImages;        // UI heart images (Heart1, Heart2, Heart3)
    public Sprite fullHeartSprite;     // Red heart sprite
    public Sprite emptyHeartSprite;    // Gray / empty heart sprite

    private bool isDead = false;       // Prevents multiple death triggers

    void Start()
    {
        // Player always starts with full health
        currentHealth = maxHealth;

        // Update hearts to show correct initial state
        UpdateHeartsUI();
    }

    void Update()
    {
        // Keep health value within valid range
        if (currentHealth < 0) currentHealth = 0;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        // Update heart icons every frame 
        // (helps when health changes in the Inspector during Play Mode)
        UpdateHeartsUI();

        // If health reaches zero → kill player once
        if (currentHealth == 0 && !isDead)
        {
            isDead = true;
            Debug.Log("Player died!");

            // Destroy the player or load a Game Over scene
            SceneManager.LoadScene("level-game-over");
        }
    }

    public void TakeDamage(int amount)
    {
        // Ignore damage if player already dead
        if (isDead) return;

        currentHealth -= amount;
        // Hearts will update automatically in Update()
    }

    public void AddHealth(int amount)
    {
        // Ignore healing if player dead
        if (isDead) return;

        currentHealth += amount;
        // Hearts update automatically in Update()
    }

    void UpdateHeartsUI()
    {
        // Update each heart (full/empty) based on current health
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHealth)
                heartImages[i].sprite = fullHeartSprite; 
            else
                heartImages[i].sprite = emptyHeartSprite;
        }
    }
}