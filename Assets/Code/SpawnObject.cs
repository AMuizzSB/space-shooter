using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    public GameObject objectToSpawn;
    [Range(0.1f, 10f)]
    public float spawnEvery = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (objectToSpawn == null)
        {
            Debug.LogError("No object to spawn assigned!");
            return;
        }
        InvokeRepeating("Spawn", spawnEvery, spawnEvery);
    }

    void Spawn()
    {
        float randomX = Random.Range(-2f, 2f);
        Vector2 spawnPosition = new Vector2(randomX, 6f);
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
