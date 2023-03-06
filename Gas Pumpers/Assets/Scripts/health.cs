using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{

    public Image[] hearts; // array of heart images
    public Sprite fullHeart; // full heart sprite
    public Sprite emptyHeart; // empty heart sprite
    public GameHandler gameHandler; // reference to the LivesManager script

    void Start() {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }

    private void Update()
    {
        int lives = gameHandler.playerLives; // get the lives variable from the LivesManager script
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
            {
                hearts[i].sprite = fullHeart; // set fullheart sprite if the index is less than the lives variable
            }
            else
            {
                hearts[i].sprite = emptyHeart; // set emptyheart sprite if the index is greater than or equal to the lives variable
            }
        }
    }
}