using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC_PatrolRandomSpace : MonoBehaviour {

       public float speed = 4f;
       private float waitTime;
       public float startWaitTime = 2f;

       public Transform moveSpot;
       public float minX;
       public float maxX;
       public float minY;
       public float maxY;

       void Start(){
              waitTime = startWaitTime;
              float randomX = Random.Range(minX, maxX);
              float randomY = Random.Range(minY, maxY);
              moveSpot.position = new Vector2(randomX, randomY);
       }

       void Update(){
              transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

              if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f){
                     if (waitTime <= 0){
                            float randomX = Random.Range(minX, maxX);
                            float randomY = Random.Range(minY, maxY);
                            moveSpot.position = new Vector2(randomX, randomY);
                            waitTime = startWaitTime;
                     } else {
                            waitTime -= Time.deltaTime;
                     }
              }
       }
}
