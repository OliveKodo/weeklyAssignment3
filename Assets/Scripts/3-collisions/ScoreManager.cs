using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // ----- SCORE -----
    public int score = 0;                       // Current player score
    public TextMeshProUGUI scoreText;           // Reference to score UI text

    // ----- MISSILES -----
    public int missiles = 0;                    // How many missiles the player has
    public int pointsPerMissile = 10;           // Every X points the player gets 1 missile
    public TextMeshProUGUI missileText;         // UI text that shows missile count

    void Start()
    {
        UpdateUI();
    }

    // Called by enemies when destroyed
   public void AddScore(int amount)
{
    score += amount;

    PlayerPrefs.SetInt("FinalScore",score);
    PlayerPrefs.Save();

    // >>> update global game status score <<<
    PlayerPrefs.SetInt("FinalScore",score);
    PlayerPrefs.Save();

    // Give a missile every time score reaches a multiple of pointsPerMissile
    if (score > 0 && score % pointsPerMissile == 0)
    {
        missiles++;
    }

    UpdateUI();
}

    // Player tries to use a missile (for "press B to clear screen")
    public bool UseMissile()
    {
        if (missiles <= 0)
            return false;   // Not enough missiles

        missiles--;          // Consume one
        UpdateUI();          // Update UI after use
        return true;
    }

    // Updates both score and missile UI
    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (missileText != null)
            missileText.text = "x " + missiles;   // Example: "x 2"
    }
}