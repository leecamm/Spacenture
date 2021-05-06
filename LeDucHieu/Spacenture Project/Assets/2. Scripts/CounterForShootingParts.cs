using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterForShootingParts : MonoBehaviour
{
    public static int collectedPartsAmount;

    // Update is called once per frame
    void Update()
    {
        // Check for the collected amount, if its 1 do this
        if (collectedPartsAmount == 1)
        {
            // Set the Image component visible
            GetComponent<Image>().enabled = true;
            //Debug.Log(collectedPartsAmount);
        }

        // Check for the collected amount, if its 2 do this
        if (collectedPartsAmount == 2)
        {
            // Set the Image component visible
            GetComponent<Image>().enabled = true;
            //Debug.Log(collectedPartsAmount);
        }

        // Check for the collected amount, if its 3 do this
        if (collectedPartsAmount == 3)
        {
            // Set the Image component visible
            GetComponent<Image>().enabled = true;
            //Debug.Log(collectedPartsAmount);
        }

        // Check for the collected amount, if its bigger than 3 do this
        if (collectedPartsAmount > 3)
        {
            // Set the Image component visible
            GetComponent<Image>().enabled = true;
            //Debug.Log(collectedPartsAmount);
        }
    }
}
