using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarOps : MonoBehaviour
{
    private GameHandler gameHandler;
    private GameObject Order;
    private GameObject Timer;

    public float gastype;
    public float snacktype;
    public float time;
    public float spot; 

    private bool obtainedSnack;
    private bool obtainedGas;
    
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        // change snack icons
        // set inactive checks

        Debug.Log("New Car:");
        Debug.Log(gastype);
        Debug.Log(snacktype);
        Debug.Log(time);
        Debug.Log(spot);
    }

    void FixedUpdate() 
    {
        // if both bools true, add a point and leave 
    }

    // Update is called once per frame
    void Update()
    {
        // decrement time 
        // when time = 0, leave 
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // if time != 0
        // check snack in player hand - access child
        //      snack match? update bool
        // destroy object 
    }
}
