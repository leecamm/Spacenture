using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vicotry : MonoBehaviour
{
    public GameObject player;

    //Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collisions tag is Player, if yes do this
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(3);
            Time.timeScale = 0.0f; //Stop game
        }
    }
}
