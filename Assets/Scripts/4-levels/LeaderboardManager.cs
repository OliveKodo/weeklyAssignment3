using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    public TextMeshProUGUI line1Text;
    public TextMeshProUGUI line2Text;
    public TextMeshProUGUI line3Text;

    const int maxEntries = 3;

    void Start()
    {
        // 1. Load last run result (score + name)
        int lastScore = PlayerPrefs.GetInt("FinalScore", 0);   // שים לב לכתיב המפתח!
        string lastName = PlayerPrefs.GetString("PlayerName", "Player");

        // 2. Load existing leaderboard from PlayerPrefs
        int[] scores = new int[maxEntries];
        string[] names = new string[maxEntries];

        for (int i = 0; i < maxEntries; i++)
        {
            scores[i] = PlayerPrefs.GetInt($"LB_Score_{i}", 0);
            names[i]  = PlayerPrefs.GetString($"LB_Name_{i}", "---");
        }

        // 3. Insert last score into the top 3 if it's high enough
        for (int i = 0; i < maxEntries; i++)
        {
            if (lastScore > scores[i])
            {
                // shift entries down
                for (int j = maxEntries - 1; j > i; j--)
                {
                    scores[j] = scores[j - 1];
                    names[j]  = names[j - 1];
                }

                scores[i] = lastScore;
                names[i]  = lastName;
                break;
            }
        }

        // 4. Save updated leaderboard back to PlayerPrefs
        for (int i = 0; i < maxEntries; i++)
        {
            PlayerPrefs.SetInt($"LB_Score_{i}", scores[i]);
            PlayerPrefs.SetString($"LB_Name_{i}", names[i]);
        }
        PlayerPrefs.Save();

        // 5. Update UI text
        if (line1Text != null) line1Text.text = $"1. {names[0]} - {scores[0]}";
        if (line2Text != null) line2Text.text = $"2. {names[1]} - {scores[1]}";
        if (line3Text != null) line3Text.text = $"3. {names[2]} - {scores[2]}";
    }
}