using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingShootingParts : MonoBehaviour
{
    public GameObject ShootingPart;

    void Start()
    {
        // Set all the ShootingPart gameObject (on screen) not active
        ShootingPart.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for the tag who is colliding, if its a player do this
        if (collision.tag == "Player")
        {
            // Add one value to the collectedPartsAmount in the CounterForShootingParts script
            CounterForShootingParts.collectedPartsAmount += 1;
            // Destroy the gameObject
            Destroy(gameObject);
            // Set the ShootingPart gameObject active
            ShootingPart.gameObject.SetActive(true);
        }
    }
}
