using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

      public GameObject scoreText;
      public static int playerScore = 0;
      public int playerLives = 5;
      private AssetBundle myLoadedAssetBundle;
      private string[] scenePaths;

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");

    }

        void Start(){
            //UpdateScore();
            // myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes");
            // scenePaths = myLoadedAssetBundle.GetAllScenePaths();
        }

      void Update()
      {
            GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
            //Debug.Log("Num active player tags :%d", player.Length);
            if (player.Length == 0){
            Debug.Log("End Scene loading: ");
            //SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
            SceneManager.LoadScene("EndScene",LoadSceneMode.Additive);
            }
            if (playerLives == 0){
                Debug.Log("Game Over!");
                Time.timeScale = 0f;
                SceneManager.LoadScene("EndScene");
            }

            Text scoreTextB = scoreText.GetComponent<Text>();
            if (SceneManager.GetActiveScene().name == "EndScene") {
                  scoreTextB.text = "FINAL SCORE: " + playerScore;
            }
      }


      public void addPoint(){
            playerScore++;
            Debug.Log("Score: " + playerScore);
            UpdateScore();
      }

      void UpdateScore(){
            Text scoreTextB = scoreText.GetComponent<Text>();
            scoreTextB.text = "" + playerScore;
      }

      public int getScore(){
        return playerScore;
      }
}
