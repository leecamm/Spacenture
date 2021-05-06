using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedStar : MonoBehaviour
{
    public float increase = 5f;
    public AudioClip speedPickupSound;
    public float volume = 0.1f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Make sure that the player is the gameObject who is colliding with the star
        GameObject player = collision.gameObject;
        // Get the players movement from the movement script
        PlayerMovement PlayerMovementScript = player.GetComponent<PlayerMovement>();

        // Check if the collisions tag is player, if yes do this
        if (collision.tag == "Player")
        {
            // Add 1 to the starAmount counter
            SpeedStarTextScript.starAmount += 1;
            // Play the sound
            AudioSource.PlayClipAtPoint(speedPickupSound, 0.9f * Camera.main.transform.position + 0.1f * transform.position, volume);
            // Destroy the gameObject
            Destroy(gameObject);
        }
    }
    
    public void PlayerHasStars()
    {
        // Check if the counter has more or 1 value, if yes do this
        if (SpeedStarTextScript.starAmount >= 1)
        {
            // Decrease the number by 1 - this means the player used one of their collected stars
            SpeedStarTextScript.starAmount -= 1;
            //Debug.Log("speed increased");
        }
    }
}

