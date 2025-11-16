using UnityEngine;
using TMPro;

public class PlayerNameInput : MonoBehaviour
{
    public TMP_InputField nameInput;   // The input field
    public GameObject namePanel;      // Panel that holds the input UI

    void Start()
    {
        // Pause the game at the beginning
        Time.timeScale = 0f;

        // Make sure the panel is visible
        if (namePanel != null)
            namePanel.SetActive(true);

        // Prepare the input field
        if (nameInput != null)
        {
            nameInput.text = "";
            nameInput.Select();
            nameInput.ActivateInputField();
        }
    }

    // This will be called when user finishes editing (presses Enter)
    public void SaveName(string submittedText)
    {
        string playerName = submittedText;

        if (string.IsNullOrWhiteSpace(playerName))
        {
            playerName = "Player";
        }

        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        Debug.Log("Saved player name: " + playerName);

        // Hide the panel
        if (namePanel != null)
            namePanel.SetActive(false);

        // Resume the game
        Time.timeScale = 1f;
    }
}