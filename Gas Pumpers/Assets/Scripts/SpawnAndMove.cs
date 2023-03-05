using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndMove : MonoBehaviour
{
    public GameObject Traffic; // The prefab of the object to spawn
    public float minSpawnInterval; // The minimum interval between spawns
    public float maxSpawnInterval; // The maximum interval between spawns
    public float moveSpeed; // The speed at which the object moves
    public float destroyXPosition; // The x-coordinate at which the object should be destroyed
    public Transform[] spawnPoints; // The spawn points for the objects
    
    private float spawnTimer = 0f; // Timer for spawning objects
    private float currentSpawnInterval; // The current interval between spawns

    void Start()
    {
        currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        // Update the spawn timer
        spawnTimer += Time.deltaTime;

        // Spawn a new object if the spawn interval has passed
        if (spawnTimer >= currentSpawnInterval)
        {
            spawnTimer = 0f;
            int randomIndex = Random.Range(0, spawnPoints.Length);

            GameObject newTraffic = Instantiate(Traffic, spawnPoints[randomIndex].position, Quaternion.identity);

            StartCoroutine(MoveObject(newTraffic.transform));
            currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    IEnumerator MoveObject(Transform objectTransform)
    {
        while (objectTransform.position.x < destroyXPosition)
        {
            // Move the object in the x-direction at the specified speed
            objectTransform.position += Vector3.right * moveSpeed * Time.deltaTime;

            yield return null;
        }

        // Destroy the object when it reaches the set x-coordinate
        Destroy(objectTransform.gameObject);
    }
}
