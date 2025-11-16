using UnityEngine;

public class MissileAbility : MonoBehaviour
{
    public KeyCode missileKey = KeyCode.B;  // key to trigger missile

    void Update()
    {
        // Check for key press each frame
        if (Input.GetKeyDown(missileKey))
        {
            TryUseMissile();
        }
    }

    void TryUseMissile()
    {
        // Find the ScoreManager in the scene
        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogWarning("MissileAbility: No ScoreManager found in scene.");
            return;
        }

        // Try to use one missile
        bool used = scoreManager.UseMissile();

        if (!used)
        {
            Debug.Log("MissileAbility: No missiles available.");
            return;
        }

        // If we get here, a missile was consumed → destroy all enemies
        DestroyAllEnemies();
    }

    void DestroyAllEnemies()
    {
        // Find all objects tagged as "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        Debug.Log("MissileAbility: Missile used, all enemies destroyed!");
    }
}