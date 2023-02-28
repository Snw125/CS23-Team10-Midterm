using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

      //public GameObject scoreText;
      //private int playerScore = 0;
      private AssetBundle myLoadedAssetBundle;
      private string[] scenePaths;

      void Start(){
            //UpdateScore();
            myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes");
            scenePaths = myLoadedAssetBundle.GetAllScenePaths();

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
      }


    //   public void AddScore(int points){
    //         playerScore += points;
    //         UpdateScore();
    //   }

    //   void UpdateScore(){
    //         Text scoreTextB = scoreText.GetComponent<Text>();
    //         scoreTextB.text = "" + playerScore;
    //   }
}
