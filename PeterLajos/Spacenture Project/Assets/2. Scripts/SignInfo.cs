using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInfo : MonoBehaviour
{
    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        Text.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collisions tag is Player, if yes do this
        if (other.tag == "Player")
        {
            Text.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the collisions tag is Player, if yes do this
        if (other.tag == "Player")
        {
            Text.gameObject.SetActive(false);
        }
    }
}
