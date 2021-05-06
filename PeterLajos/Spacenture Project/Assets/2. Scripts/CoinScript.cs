using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioClip coinSound;
    public float volume = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for the tag who is colliding with the coin, if its player do that
        if(collision.tag == "Player")
        {
            // Add one to the coinAmount in the CoinTextScript script
            CoinTextScript.coinAmount += 1;
            // Play the sound
            AudioSource.PlayClipAtPoint(coinSound, 0.9f*Camera.main.transform.position + 0.1f*transform.position, volume);
            // Destroy the gameObject 
            Destroy(gameObject);
        }
    }
}
