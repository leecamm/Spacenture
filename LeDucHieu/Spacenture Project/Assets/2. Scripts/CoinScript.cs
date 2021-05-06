using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for the tag who is colliding with the coin, if its player do that
        if(collision.tag == "Player")
        {
            // Add one to the coinAmount in the CoinTextScript script
            
            CoinTextScript.coinAmount += 1;
            // Destroy the gameObject 
            Destroy(gameObject);
        }
        
    }
    
}
