using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gas_cars : MonoBehaviour
{
    public GameObject Car; // The prefab of the object to spawn
    public List<Vector3> spawnPositions; // The positions to spawn the objects at
    public float minWaitTime; // The minimum time to wait before moving the object
    public float maxWaitTime; // The maximum time to wait before moving the object
    
    public List<bool> isSpotFull;
    public List<GameObject> Timers;
    public int numGasTypes;
    public int numSnackTypes;
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
            GameObject carTimer = Timers[index];
            

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
                newCarScript.Timer = carTimer;

                isSpotFull[index] = true;

                // Calculate a random wait time between minWaitTime and maxWaitTime
                waitTime = Random.Range(minWaitTime, maxWaitTime);
                // Wait for the specified amount of time
                yield return new WaitForSeconds(waitTime);
            }
            
        }
    }


}
