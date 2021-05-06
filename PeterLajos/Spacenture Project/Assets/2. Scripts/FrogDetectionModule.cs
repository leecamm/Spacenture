using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDetectionModule : MonoBehaviour
{
    public Animator animator;

    public float speed = 10f;

    [HideInInspector]
    // Does the enemy has a target
    public bool hasTarget = false;
    [HideInInspector]
    // The target the enemy wants to get closer
    public GameObject target;

    // Update is called once per frame
    private void Update()
    {
        if (hasTarget)
        {
            // Get distance between the target and the enemy
            float distance = Vector3.Distance(transform.position, target.transform.position);
            // If the enemy is further than 2 units
            if (distance > 2)
            {
                // Turn on the enemyAI script
                GetComponent<EnemyAI>().enabled = true;
                GetComponent<SoundsForAssets>().enabled = true;
            }
            // attack(); // Start to attack
        }
        else
        {
            // Turn off the enemyAI script
            GetComponent<EnemyAI>().enabled = false;
            GetComponent<SoundsForAssets>().enabled = false;
        }
    }

    // If the player enters the enemy collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for the collision name, if its Player do this
        if (collision.name.Equals("Player"))
        {
            // Set the collision to target
            target = collision.gameObject;
            // Now the enemy has a target
            hasTarget = true;
            // Play the walking animation while chasing
            animator.SetBool("isWalking", true);
        }
    }

    // If the player leaves the enemy collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check for the collision name, if its Player do this
        if (collision.name.Equals("Player"))
        {
            // Set target to nobody
            target = null;
            // There is no target for the enemy
            hasTarget = false;
            // Play the walking animation while chasing
            animator.SetBool("isWalking", false);
        }
    }
}
