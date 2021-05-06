using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player player;
    public Health health;

    // Start is called before the first frame update
    void Start()
    {
        // Get the player gameObject with the tag Player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    //Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        // This part is for the spikes on the map
        // Check if the collisions tag is Player, if yes do this
        if (other.tag == "Player")
        {
            // Do damage on player
            health.Damage(5);
        }
    }
}
