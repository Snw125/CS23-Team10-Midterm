using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyEnemy : MonoBehaviour
{
    public GameObject enemy;
    private NPC_PatrolRandomSpace script;
    
    // Start is called before the first frame update
    void Start()
    {
        script = enemy.GetComponent<NPC_PatrolRandomSpace>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
              if (other.gameObject.tag == "Player") {
                    //notify enemy
                    Debug.Log("Enter");
                    script.chase = true;
              }
    }

    void OnTriggerExit2D(Collider2D other){
            if (other.gameObject.tag == "Player") {
                // stop notifiy
                Debug.Log("Exit");
                script.chase = false;
            }
    }
}
