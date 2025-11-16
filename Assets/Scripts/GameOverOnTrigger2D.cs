using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class GameOverOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;
    
    [Tooltip("Name of the game over scene")]
    [SerializeField] string gameOverSceneName = "level-game-over";  

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == triggeringTag && enabled) 
        {
            Debug.Log("Game over!");
            
            
            SceneManager.LoadScene(gameOverSceneName);
        }
    }

    private void Update() 
    {
        /* Just to show the enabled checkbox in Editor */
    }
}