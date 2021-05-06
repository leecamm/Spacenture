using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedStarTextScript : MonoBehaviour
{
    Text text;

    public static int starAmount;

    // Start is called before the first frame update
    void Start()
    {
        // Get the text component on start - from the screen
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Display the starAmount as text and convert it to string
        text.text = starAmount.ToString();
    }
}
