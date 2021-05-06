using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakingBullet : MonoBehaviour
{
    public int health = 1;

    public GameObject deathEffect;

    public void TakeDamage (int damage)
    {
        // When taking damage remove the amount of damage from health
        health -= damage;

        // Check if the health is smaller or is 0
        if(health <= 0)
        {
            // Do the Die function
            Die();
        }
    }

    void Die()
    {
        // Playe the death effect
        /*Instantiate(deathEffect, transform.position, Quaternion.identity);*/
        // Destroy the gameObject
        Destroy(gameObject);
    }
}
