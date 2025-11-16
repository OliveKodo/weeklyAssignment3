using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    public GameObject heartPrefab;
    public float spawnInterval = 8f;  // spawn every few seconds
    public float minX = -8f;
    public float maxX = 8f;
    public float spawnY = 6f;

    void Start()
    {
        InvokeRepeating("SpawnHeart", 5f, spawnInterval);
    }

    void SpawnHeart()
    {
        // spawn heart ONLY if player's health < max
        PlayerHealth player = FindFirstObjectByType<PlayerHealth>();
       
        float randomX = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(randomX, spawnY, 0);

        Instantiate(heartPrefab, pos, Quaternion.identity);
    }
}