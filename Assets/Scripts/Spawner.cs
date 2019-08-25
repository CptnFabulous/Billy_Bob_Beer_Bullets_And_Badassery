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
    float spawnTimer = 99999999;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay && (amountToSpawn > 0 || spawnInfinitely == true))
        {
            for (int i = 0; i < spawnBatchSize; i++)
            {
                Vector3 spawnVector = spawnLocations[Random.Range(0, spawnLocations.Length - 1)].position + Random.insideUnitSphere * spawnRadius;
                Instantiate(objectToSpawn, spawnVector, Quaternion.identity);
                spawnTimer = 0;
                if (spawnInfinitely == false)
                {
                    amountToSpawn -= 1;
                }
            }
            
        }
    }
}
