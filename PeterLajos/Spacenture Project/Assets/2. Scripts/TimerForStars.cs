using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class TimerForStars : MonoBehaviour
{
    public float timeForSpeedEffect = 15.0F;
    public float timeRemaining = 15.0F;
    public bool timerIsRunning = false;
    public Text textForTime;

    public SpeedStar speedStarScript;
    public PlayerMovement PlayerMovementScript;

    public CinemachineVirtualCamera vcam;

    private void Start()
    {
        // Get the Text component for textForTime
        textForTime = GetComponent<Text>();
    }

    void Update()
    {
        // Check if the timer started to run - its counting down
        if (timerIsRunning)
        {
            // Check if the time remaining is still bigger than 0
            if (timeRemaining > 0)
            {
                // Make the time remaining decrease by Time.deltaTime
                timeRemaining -= Time.deltaTime;

                // Make the numbers as whole numbers like: 1, 2, 3, etc. and not like 1.01, 1.05, etc.
                float timeToDesplay = Mathf.Floor(timeRemaining);
                // Display the time in the text box on the screen
                textForTime.text = timeToDesplay.ToString();
            }
            else
            {
                // Set the time back to the timeForSpeedEffect
                timeRemaining = timeForSpeedEffect;
                // Set the time is running bool false, because it is not running
                timerIsRunning = false;

                // If the timer is not running display "F", because this it the button the player should push to acivate the ability
                textForTime.text = "F";

                // Increace the players speen the the movement script
                PlayerMovementScript.runSpeed -= speedStarScript.increase;

                // Change camera view back to normal
                vcam.m_Lens.OrthographicSize = 5f;
            }
        }
    }

    public void StartStarTimer()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
}