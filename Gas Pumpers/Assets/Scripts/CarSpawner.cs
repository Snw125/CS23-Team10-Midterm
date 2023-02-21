using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

public class CarSpawner : MonoBehaviour {

      //Object variables
      public GameObject CarPrefab;
      public Transform[] spawnPoints;
      private int rangeEnd;
      private Transform spawnPoint;

      //Timing variables
      public float spawnRangeStart = 0.5f;
      public float spawnRangeEnd = 1.2f;
      private float timeToSpawn;
      private float spawnTimer = 0f;
      public bool spawnflag;

      void Start(){
              //assign the length of the array to the end of the random range
             rangeEnd = spawnPoints.Length - 1 ;
             spawnflag = true;
       }

      async void FixedUpdate(){
            timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
            spawnTimer += 0.0015f;
            if (spawnTimer >= timeToSpawn){
                while(spawnflag == true){

                    spawnCar();
                    spawnTimer =0f;

                    await Task.Delay(6000);

                    spawnflag = false;

                    await Task.Delay(7000);

                    spawnflag = true;

                }
                  
            }
      }

      void spawnCar(){
            int SPnum = Random.Range(0, rangeEnd);
            spawnPoint = spawnPoints[SPnum];
            Instantiate(CarPrefab, spawnPoint.position, Quaternion.identity);
      }
}