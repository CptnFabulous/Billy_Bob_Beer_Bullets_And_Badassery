using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Tooltip("Objects/enemies to spawn")]
    public GameObject objectToSpawn;
    [Tooltip("How many objects will be spawned")]
    public int amountToSpawn;
    [Tooltip("How many to spawn at a time")]
    public int spawnBatchSize;
    [Tooltip("If ticked, spawns objects infinitely without running out")]
    public bool spawnInfinitely;
    [Tooltip("Randomly selects a location to spawn at")]
    public Transform[] spawnLocations;
    [Tooltip("Radius around the transform to spawn objects, prevents overlap")]
    public float spawnRadius;
    [Tooltip("Time between spawning")]
    public float spawnDelay;
    float spawnTimer; // Used to count up to the next spawn
    
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    */

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime; // Spawn timer counts up
        if (spawnTimer >= spawnDelay && (amountToSpawn > 0 || spawnInfinitely == true)) // If spawn has delayed for long enough and there are remaining objects to spawn OR the spawner is set to spawn infinitely
        {
            for (int i = 0; i < spawnBatchSize; i++) // Spawns multiple times based on spawnBatchSize variable
            {
                // Randomly selects a spawn point, then spawns the gameObject within a short vicinity of said spawn point to ensure they are not spawned inside each other.
                Vector2 sr = Random.insideUnitCircle * spawnRadius;
                Vector3 sz = new Vector3(sr.x, 0, sr.y);
                Vector3 spawnVector = spawnLocations[Random.Range(0, spawnLocations.Length - 1)].position + sz;
                Instantiate(objectToSpawn, spawnVector, Quaternion.identity); // Instantiates the gameObject at the specified spawn position.
                spawnTimer = 0; // Resets spawn timer to count up for the next spawn
                if (spawnInfinitely == false)
                {
                    amountToSpawn -= spawnBatchSize; // Depletes from amount spawned
                }
            }
            
        }
    }
}
