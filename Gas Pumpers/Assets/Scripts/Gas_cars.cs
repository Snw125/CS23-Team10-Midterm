using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas_cars : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab of the object to spawn
    public List<Vector3> spawnPositions; // The positions to spawn the objects at
    public float minWaitTime; // The minimum time to wait before moving the object
    public float maxWaitTime; // The maximum time to wait before moving the object
    public float moveSpeedY; // The speed to move the object in the y direction
    public float destinationPositionY; // The y position to move the object towards
    public Vector3 moveDirectionX; // The direction to move the object in the x direction
    public float moveSpeedX; // The speed to move the object in the x direction

    private GameObject spawnedObject; // The object that was spawned
    private float waitTime; // The amount of time to wait before moving the object in the y direction

    void Start()
    {
        // Start the coroutine to spawn and move the object
        StartCoroutine(SpawnAndMoveObject());
    }

    IEnumerator SpawnAndMoveObject()
    {
        while (true) // Loop forever
        {
            // Choose a random spawn position from the list
            Vector3 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Count)];
            
            // Spawn the object at the chosen position
            spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Calculate a random wait time between minWaitTime and maxWaitTime
            waitTime = Random.Range(minWaitTime, maxWaitTime);

            // Wait for the specified amount of time
            yield return new WaitForSeconds(waitTime);

            // Calculate the destination position in the y direction
            Vector3 destinationY = new Vector3(spawnedObject.transform.position.x, destinationPositionY, spawnedObject.transform.position.z);

            // Move the object in the y direction
            while (Vector3.Distance(spawnedObject.transform.position, destinationY) > 0.1f)
            {
                spawnedObject.transform.position = Vector3.MoveTowards(spawnedObject.transform.position, destinationY, moveSpeedY * Time.deltaTime);
                yield return null;
            }

            // Calculate the destination position in the x direction
            Vector3 destinationX = spawnedObject.transform.position + moveDirectionX;

            // Move the object in the x direction
            while (Vector3.Distance(spawnedObject.transform.position, destinationX) > 0.1f)
            {
                spawnedObject.transform.position = Vector3.MoveTowards(spawnedObject.transform.position, destinationX, moveSpeedX * Time.deltaTime);
                yield return null;
            }

            // Destroy the object after it has reached its final destination
            Destroy(spawnedObject);
        }
    }
}
