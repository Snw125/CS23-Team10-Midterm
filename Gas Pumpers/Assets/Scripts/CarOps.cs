using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarOps : MonoBehaviour
{
    private GameHandler gameHandler;
    private Gas_cars spawner;
    private GameObject Order;
    private GameObject GasCheckImg;
    private GameObject SnackCheckImg;
    private SpriteRenderer GasImage;
    private SpriteRenderer SnackImage;
    public GameObject Timer;
    public Image TimeBar;

    public SpriteRenderer carSprite;

    public int gastype;
    public int snacktype;
    public float time;
    public int spot; 

    public bool obtainedSnack;
    public bool obtainedGas;
    public float currtime;
    private bool bonus;
    private GameObject playerHolding;
    private bool match;
    
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        spawner = GameObject.Find("Car_pump1").GetComponent<Gas_cars>();

        TimeBar = Timer.transform.GetChild(0).GetComponent<Image>();
        Timer.SetActive(true);
        currtime = time;

        Order = transform.GetChild(1).gameObject;
        GasCheckImg = Order.transform.GetChild(1).gameObject;
        SnackCheckImg = Order.transform.GetChild(3).gameObject;
        GasImage = Order.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        SnackImage = Order.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>();

        // set inactive checks
        obtainedGas = false;
        obtainedSnack = false;
        GasCheckImg.SetActive(false);
        SnackCheckImg.SetActive(false);
        // change snack icons
        Debug.Log(snacktype);
        Debug.Log(gastype);

        if (gastype == 2) {
            carSprite.sprite = Resources.Load<Sprite>("Blue_Car_Top_View");
            GasImage.sprite = Resources.Load<Sprite>("Blue_Gas_Can");
        }
        if (gastype == 3) {
            carSprite.sprite = Resources.Load<Sprite>("Yellow_Car_Top_View");
            GasImage.sprite = Resources.Load<Sprite>("Yellow_Gas_Can");
        }

        if (snacktype == 2) {
            SnackImage.sprite = Resources.Load<Sprite>("Hot_Dog");
        }
        if (snacktype == 3) {
            SnackImage.sprite = Resources.Load<Sprite>("Soda_Bottle");
        }

    }

    void FixedUpdate() 
    {
        // if both bools true, add a point and leave 
        if (obtainedGas) {
            GasCheckImg.SetActive(true);
        }
        if (obtainedSnack) {
            SnackCheckImg.SetActive(true);
        }
        if (obtainedGas && obtainedSnack) {
            if (bonus == false) {
                gameHandler.addPoint();
                if (gameHandler.playerLives < 5) {
                    gameHandler.playerLives++;
                }
                bonus = true;
            }
            
            StartCoroutine(Leave());
        }
        
        // when time = 0, leave 
        if (currtime/time <= 0) {
            StartCoroutine(Leave());
        }
    }

    // Update is called once per frame
    void Update()
    {
        // decrement time 
        currtime -= 1f * Time.deltaTime;

        TimeBar.fillAmount = currtime/time;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        // if time != 0
        if (currtime/time > 0) {
            // check snack in player hand - access child
            if (other.gameObject.tag == "Player") {
                //Debug.Log("whoa there fella thats some mighty fine snack gas you got right there");
                playerHolding = other.transform.GetChild(1).GetChild(0).gameObject;
                if (playerHolding.tag == "Gas") {
                    // set bool 
                    match = false; 

                    // check if right type 
                    if (playerHolding.name == "Gas(Clone)" && gastype == 1) {
                        match = true;
                    }
                    if (playerHolding.name == "Blue_Gas(Clone)" && gastype == 2) {
                        match = true;
                    }
                    if (playerHolding.name == "Yellow_Gas(Clone)" && gastype == 3) {
                        match = true;
                    }

                    if (!obtainedGas && match) {
                        obtainedGas = true;

                        // destroy item, it has been used 
                        other.transform.GetComponent<PlayerCart>().cartFilled = false;
                        Destroy(playerHolding);
                    }
                }
                if (playerHolding.tag == "Snack") {
                    // set bool 
                    match = false; 

                    // check if right type 
                    if (playerHolding.name == "Snack(Clone)" && snacktype == 1) {
                        match = true;
                        Debug.Log("Match!");
                    }
                    if (playerHolding.name == "Hot_Dog(Clone)" && snacktype == 2) {
                        match = true;
                    }
                    if (playerHolding.name == "Soda_Bottle(Clone)" && snacktype == 3) {
                        match = true;
                    }

                    if (!obtainedSnack && match) {
                        obtainedSnack = true;

                        // destroy item, it has been used 
                        other.transform.GetComponent<PlayerCart>().cartFilled = false;
                        Destroy(playerHolding);
                    }
                }
            }
            
            
        }
    }

    IEnumerator Leave() {
        yield return new WaitForSeconds(1f);
        Order.SetActive(false);
        Timer.SetActive(false);
        
        Vector2 destinationY = new Vector2(transform.position.x, -.5f);

        // Move the object in the y direction
        while (Vector2.Distance(transform.position, destinationY) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, destinationY, .2f * Time.deltaTime);
            yield return null;
        }

        // Calculate the destination position in the x direction
        Vector2 destinationX = new Vector2(14, transform.position.y);

        // Move the object in the x direction
        while (Vector2.Distance(transform.position, destinationX) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, destinationX, .2f * Time.deltaTime);
            yield return null;
        }
        // set the spot to empty now 
        spawner.isSpotFull[spot] = false;

        // Destroy the object after it has reached its final destination
        bonus = false;
        Destroy(transform.gameObject);
    }

}
