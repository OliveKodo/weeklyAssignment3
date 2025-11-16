using UnityEngine;

public class ShowLeaderboard : MonoBehaviour
{
    public GameObject leaderboardPanel;
    public GameObject gameOverPanel;   
    public float delay = 3f;

    void Start()
    {
        if (leaderboardPanel != null)
            leaderboardPanel.SetActive(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Invoke("ShowNow", delay);
    }

    void ShowNow()
    {
        if (leaderboardPanel != null)
            leaderboardPanel.SetActive(true);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }
}