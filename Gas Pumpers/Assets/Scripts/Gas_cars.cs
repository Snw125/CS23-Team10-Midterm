using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas_cars : MonoBehaviour
{
    public GameObject Car; // The prefab of the object to spawn
    public List<Vector3> spawnPositions; // The positions to spawn the objects at
    public float minWaitTime; // The minimum time to wait before moving the object
    public float maxWaitTime; // The maximum time to wait before moving the object
    
    // public float moveSpeedY; // The speed to move the object in the y direction
    // public float destinationPositionY; // The y position to move the object towards
    // public Vector3 moveDirectionX; // The direction to move the object in the x direction
    // public float moveSpeedX; // The speed to move the object in the x direction
    
    public List<bool> isSpotFull;
    public float numGasTypes;
    public float numSnackTypes;
    public float carTimerMin;
    public float carTimerMax;

    private CarOps newCarScript;

    private GameObject newCar; // The object that was spawned
    private float waitTime; // The amount of time to wait before moving the object in the y direction

    void Start()
    {
        // Start the coroutine to spawn
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        
        while (true) // Loop forever
        {
            // Choose a random spawn position from the list of spawn gameobjs
            int index = Random.Range(0, spawnPositions.Count);
            Vector3 spawnPosition = spawnPositions[index];
            
            

            // if spot is full, reroll. 
            if (isSpotFull[index]) {
                Debug.Log("Spot Full!");
                yield return new WaitForSeconds(waitTime);
            }
            else { // else, fill spot.
                Debug.Log("New spot!");
                // Spawn the object at the chosen position
                newCar = Instantiate(Car, spawnPosition, Quaternion.identity);
                newCarScript = newCar.GetComponent<CarOps>();
                newCarScript.gastype = Random.Range(1, numGasTypes);
                newCarScript.snacktype = Random.Range(1, numSnackTypes);
                newCarScript.time = Random.Range(carTimerMin, carTimerMax);
                newCarScript.spot = index;

                isSpotFull[index] = true;

                // Calculate a random wait time between minWaitTime and maxWaitTime
                waitTime = Random.Range(minWaitTime, maxWaitTime);
                // Wait for the specified amount of time
                yield return new WaitForSeconds(waitTime);
            }
            
        }
    }


    // leaving script

    // // Calculate the destination position in the y direction
    //     Vector3 destinationY = new Vector3(newCar.transform.position.x, destinationPositionY, newCar.transform.position.z);

    //     // Move the object in the y direction
    //     while (Vector3.Distance(newCar.transform.position, destinationY) > 0.1f)
    //     {
    //         newCar.transform.position = Vector3.MoveTowards(newCar.transform.position, destinationY, moveSpeedY * Time.deltaTime);
    //         yield return null;
    //     }

    //     // Calculate the destination position in the x direction
    //     Vector3 destinationX = newCar.transform.position + moveDirectionX;

    //     // Move the object in the x direction
    //     while (Vector3.Distance(newCar.transform.position, destinationX) > 0.1f)
    //     {
    //         newCar.transform.position = Vector3.MoveTowards(newCar.transform.position, destinationX, moveSpeedX * Time.deltaTime);
    //         yield return null;
    //     }

    //     // Destroy the object after it has reached its final destination
    //     Destroy(newCar);
}
