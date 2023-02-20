using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Cart : MonoBehaviour
{

    private int cartCapacity = 1;

    public int numItems;
    private bool hasInitialized;

    public GameObject cart;
    public GameObject currentItem;


    float time;
    float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
      //cartCapacity = cart.transform.childCount;
      hasInitialized = false;
      numItems = 0;

      time = 0f;
      timeDelay = 3f;


      // currentItemIndex = 0;
      // currentItem = items[0];



    }

    // Update is called once per frame
    void Update()
    {
        //time = time + 1f * Time.deltaTime;
        // Whenever someone adds something to inventory,
        if(Input.GetKeyDown(KeyCode.R) && numItems < cartCapacity){
          //StartCoroutine (Test ());
          //if (time >= timeDelay) {
            //time = 0f;
          Debug.Log("Commence");
          Invoke(nameof(Test), 2.0f);
          numItems = cart.transform.childCount;
          Debug.Log(numItems);
          //currentItem = cart.transform.GetChild(0).gameObject;
          currentItem = cart.transform.GetChild(1).gameObject;
          currentItem.SetActive(true);
          hasInitialized = true;
          Debug.Log("We are Here");

          if(!hasInitialized){
            hasInitialized = true;
          }
        //}
        }// end if

        if(hasInitialized){
          numItems = cart.transform.childCount;
          Debug.Log(numItems);
          currentItem = cart.transform.GetChild(0).gameObject;
          currentItem.SetActive(true);
        }




/*
      // continuosly add new inventory automatically
      if(hasInitialized){
        numItems = cart.transform.childCount;
        for(int i = 0; i < numItems; i++){
          items[i] = cart.transform.GetChild(i).gameObject;
          items[i].SetActive(false);
        }
        items[currentItemIndex].SetActive(true);
        currentItem = items[currentItemIndex];
      }
      */


    }

    IEnumerator Test(){
    yield return new WaitForSeconds(0);
    numItems = cart.transform.childCount;
    Debug.Log(numItems);
    currentItem = cart.transform.GetChild(0).gameObject;
    currentItem.SetActive(true);
    Debug.Log("Wait is ova");
  }
}
