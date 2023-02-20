using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;


public class DisplayCar1 : MonoBehaviour {

      public GameObject CarArt;
      public bool isVisible = true;

      public int run = 1;

      void Start(){
           isVisible = true; //new command to disable the object through the bool
      }

      async void Update(){

        while(run == 1){

            if (isVisible == true){
                  CarArt.SetActive(true);
            } else {
                  CarArt.SetActive(false);
            }

            System.Random rnd = new System.Random();

            int DelayTime;
            DelayTime = rnd.Next(3000,7000);

            await Task.Delay(DelayTime);

            isVisible = false;
        }
            

            

            // if (Input.GetKeyDown(KeyCode.Space)){
            //       isVisible = !isVisible;
                //   StopCoroutine(DelayCarAway());
                //   StartCoroutine(DelayCarAway());
            // }
      }

      IEnumerator DelayCarAway(){
           yield return new WaitForSeconds(2f);
           isVisible = false;
      }
}