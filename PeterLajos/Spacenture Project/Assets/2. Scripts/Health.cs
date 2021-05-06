using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public AudioSource hurtAudio;
    [SerializeField] private AudioClip[] hurtSounds;
    public float hurtPitch;

    public Animator animator;

    public GameObject RedFlashEffect;

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        // Set the health to numOfHearts
        health = numOfHearts;

        // Randomize the pitch
        hurtPitch = Random.Range(1.0f, 1.5f);
    }

    void Update()
    {
        // Check for heart amount
        for (int i = 0; i < hearts.Length; i++)
        {
            // If the health is bigger than the numOfHearts set the health back to numOfHearts
            if (health > numOfHearts)
            {
                health = numOfHearts;
            }
            // If the health is 0
            if (health == 0)
            {
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
        // Make sound when taking damage
        int n = Random.Range(1, hurtSounds.Length);
        hurtAudio.clip = hurtSounds[n];
        hurtAudio.pitch = hurtPitch;
        hurtAudio.PlayOneShot(hurtAudio.clip);
        hurtPitch = Random.Range(1.0f, 1.5f);

        animator.SetTrigger("hurt");

        health -= damage;

        if (health <= 0)
        {
            SceneManager.LoadScene(2);
            Time.timeScale = 0.0f; //Stop game
        }
    }
}
