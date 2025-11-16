using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        // Load the saved score
        int finalScore = PlayerPrefs.GetInt("Finalscore", 0);

        // Display it
        if (scoreText != null)
        {
            scoreText.text = finalScore.ToString();
        }
    }
}