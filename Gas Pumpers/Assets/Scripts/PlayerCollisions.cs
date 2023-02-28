using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    public GameObject gameOverText;

    void Start() {
            gameOverText = GameObject.FindWithTag("GameOver");
            gameOverText.SetActive(false);
    }
    
    public void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.tag == "Car") {
                    Debug.Log("Game Over!");
                    gameOverText.SetActive(true);
                    Time.timeScale = 0;
            }
            if (other.gameObject.tag == "Enemy") {
                    Debug.Log("Game Over!");
                    gameOverText.SetActive(true);
                    Time.timeScale = 0;
            }
    }
}
