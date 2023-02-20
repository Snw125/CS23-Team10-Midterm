using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;

public class CarMovement : MonoBehaviour {
      public float moveSpeed = 1f;

      public Vector2 movement;

      

      private Rigidbody2D rb;

      public bool StopFlag;
      public int milliseconds = 10000;

      
      void Start(){
          rb = GetComponent<Rigidbody2D>(); 
          movement.x = 1f;

          StopFlag = false;
      }

      void Update(){

            
           
      }

      async void FixedUpdate(){

        
        while(StopFlag == false){

            
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            await Task.Delay(6000);
            
            StopFlag = true;
            await Task.Delay(7000);

            StopFlag = false;

        }

        
        

        

            
           
      }
};
