using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelPickup : MonoBehaviour
{
    public bool pickUpAllowed;

    // Start is called before the first frame update
    void Start()
    {
      pickUpAllowed = false;

    }

    // Update is called once per frame
    void Update()
    {
      if (pickUpAllowed && Input.GetKeyDown(KeyCode.R)){
        FuelPickUp();
      }

    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
          pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
          pickUpAllowed = false;
        }
    }

    private void FuelPickUp(){
        //Destroy(gameObject);
        GameObject desiredParentGameObject = GameObject.FindGameObjectsWithTag("Cart")[0];
        GameObject targetGameObject = gameObject;
        int numCartItems = desiredParentGameObject.transform.childCount;
        if(numCartItems < 1){targetGameObject.transform.parent = desiredParentGameObject.transform; Debug.Log(numCartItems); }
    }
}
