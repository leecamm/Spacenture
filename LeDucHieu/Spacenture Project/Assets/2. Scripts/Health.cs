using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject gameOver;

    public Animator redFlash;

    void Start()
    {
        // Set the health to numOfHearts
        health = numOfHearts;
        // Set gameOver gameobject false so its not visible when starting the game
        gameOver.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check for heart amount
        for (int i = 0; i < hearts.Length; i++)
        {
            // If the health is bigger than the numOfHearts set the health back to numOfHearts
            if(health > numOfHearts)
            {
                health = numOfHearts;
            }
            // If the health is 0
            if(health == 0)
            {
                //Debug.Log("GameOver");
                // Set the gameOver gameObject true so its visible
                //gameOver.gameObject.SetActive(true);
                //Load Lose Screen
                SceneManager.LoadScene(2);
                // Froze/Stop the game
                Time.timeScale = 0.0f;
            }

            // Check the hearts if they are smaller than health
            if (i < health)
            {
                // Change the image to fullHeart 
                hearts[i].sprite = fullHeart;
            }
            else
            {
                // Change the image to emptyHeart
                hearts[i].sprite = emptyHeart;
            }

            // Check if the hearts are smaller than numOfHearts
            if (i < numOfHearts)
            {
                // Enable the hearts
                hearts[i].enabled = true;
            } else
            {
                // Disable the hearts
                hearts[i].enabled = false;
            }
        }
    }

    // When the player falls into the void or into spikes
    public void Damage(int dmg)
    {
        // Set health to 0
        health = 0;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Debug.Log("GameOver");
            //gameOver.gameObject.SetActive(true);
            SceneManager.LoadScene(2);
            Time.timeScale = 0.0f; //Stop game
        }
    }
}
