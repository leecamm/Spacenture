using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounterWinning : MonoBehaviour
{
    Text text;
    CoinScript numOfCoin;
    public static int coinAmount;

    // Start is called before the first frame update
    void Start()
    {
        // When starting the game search for the Text component
        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Display the coinAmoint in the text text and convert it to string
        text.text = coinAmount.ToString();
        text.text = numOfCoin.ToString();
    }
}
