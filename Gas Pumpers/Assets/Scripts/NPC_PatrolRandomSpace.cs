using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC_PatrolRandomSpace : MonoBehaviour {

    public float speed = 1f;
    private float waitTime;
    public float startWaitTime = 2f;
    public float waitTimeChase = 1f;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public bool chase;
    public GameObject player;

    private int previousScore;

    void Start(){
        waitTime = startWaitTime;
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        moveSpot.position = new Vector2(randomX, randomY);
        chase = false;
        player = GameObject.FindWithTag("Player");
        previousScore = GameHandler.playerScore;
    }

    void Update(){
        if (GameHandler.playerScore >= previousScore + 5)
        {
            speed += 2f;
            previousScore = GameHandler.playerScore;
        }

        if (chase) {
            //Debug.Log("CHASING!!!");
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            //StartCoroutine(chasePlayer());
        }
        else {
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

    // Improved Chase = Delay to enemy movement. do some math with the vectors you can get 
    // IEnumerator chasePlayer(){
    //         yield return new WaitForSeconds(waitTimeChase);
    //         float distx = Mathf.Abs(transform.position.x - player.transform.position.x);
    //         float disty = Mathf.Abs(transform.position.y - player.transform.position.y);

    //         Vector2 destination = new Vector2(transform.position.x + distx/2, transform.position.y+ disty/2);
            
    //         transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    // }
}
