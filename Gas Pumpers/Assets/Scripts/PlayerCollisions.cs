using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    private GameHandler gameHandler;

    void Start() {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }
    
    public void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.tag == "Car") {
                    gameHandler.playerLives--;
                    Debug.Log("Lives: " + gameHandler.playerLives);
            }
            if (other.gameObject.tag == "Enemy") {
                    gameHandler.playerLives--;
                    Debug.Log("Lives: " + gameHandler.playerLives);
            }
    }
}
