using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public PlayerCart cart;

    void Update()
    {
        // adding to cart
        if ((cart.nearTrash)&&(cart.cartFilled)){
            if(Input.GetKeyDown(KeyCode.Space)){
                cart.Destroy();
            }   
        }
    }

    public void OnTriggerEnter2D(Collider2D other) { 
        if (other.gameObject.tag == "Player") {
                cart.nearTrash = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other) { 
        if (other.gameObject.tag == "Player") {
                cart.nearTrash = false;
        }
    }
}
