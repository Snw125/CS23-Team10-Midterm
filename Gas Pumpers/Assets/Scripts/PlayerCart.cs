using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCart : MonoBehaviour
{

public Transform pCart;
public bool cartFilled;
public bool nearItem;
public GameObject theItem;



    // Start is called before the first frame update
    void Start()
    {
        cartFilled = false;
        nearItem = false;
        theItem = null;
    
    }

    // Update is called once per frame
    void Update()
    {
        // adding to cart
        if ((nearItem)&&(!cartFilled)){
            if(Input.GetKeyDown(KeyCode.Space)){
                theItem.transform.parent = pCart;
                Debug.Log("Added to cart!");
                cartFilled = true;
            }
           
        }
        // remocing from cart
        // else if (cartFilled){
        //     if(Input.GetKeyDown(KeyCode.R)){
        //         theItem.transform.SetParent(null);
        //         Destroy(theItem);
        //         theItem = null;
        //         cartFilled = false;
        //         Debug.Log("Removed from cart!");
        //     }
        //     //if hit spacebar
        //     //set parent of theItem = world
        //     // theItem = null;
        //     // cartFilled = false;
        // }
    }

    public void OnTriggerEnter2D(Collider2D other){

    if (!cartFilled){
        if (other.gameObject.tag == "Gas"){
          Debug.Log("fuel, can pickup!");
          nearItem = true;
          theItem = other.gameObject;
        }
        else if (other.gameObject.tag == "Snack"){
          Debug.Log("snack, can pickup!");
          nearItem = true;
          theItem = other.gameObject;
        }

        //if other tag = pickable item
        //nearItem= true;
        //theItem = other.gameObject;}


        }
}

public void OnTriggerExit2D(Collider2D other){
    
    if (other.gameObject.tag == "Gas" || other.gameObject.tag == "Snack"){
        nearItem = false;
    }
   

    //if other tag = pickable item
    //nearItem= false;

}


}
