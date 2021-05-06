using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{

    public Char_Controller controller;
    public Animator animator;
    public SpeedStar speedStarScript;
    public TimerForStars timerForStarsScript;

    public CinemachineVirtualCamera vcam;

    public float runSpeed = 20f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;
    

    // Update is called once per frame
    void Update()
    {
        // Letting the game know what is going to be the movement, and * it with the runSpeed
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // If the player is running/moving make the correct animation for that
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // ---------- SPEEDSTAR ----------
        // If the player presses "F" do this
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Check if the timer is running for speed or not
            if (timerForStarsScript.timerIsRunning == true)
            {
                // If it is running, keep the starAmount as it is
                SpeedStarTextScript.starAmount = SpeedStarTextScript.starAmount;
            }
            // If it is not running do this
            else if (SpeedStarTextScript.starAmount >= 1)
            {
                // Do the function from speedStarScript
                speedStarScript.PlayerHasStars();
                // Increase the players movement
                runSpeed += speedStarScript.increase;
                // Change camera view
                vcam.m_Lens.OrthographicSize = 6f;
                // Start the timer
                timerForStarsScript.StartStarTimer();
            }
        }
        //---------- SPEEDSTAR END ----------

        // If the player presses the "Jump" button do this
        if (Input.GetButtonDown("Jump"))
        {
            // Set jumping true
            jump = true;
            // Play the jumping animation while jumping
            animator.SetBool("IsJumping", true);
        } 

        // If the player presses the "Crouch" button do this 
        if (Input.GetButtonDown("Crouch"))
        {
            // Set crouching true
            crouch = true;
        }
        // If the player is not pressing the "Crouch" cutton anymore do this
        else if (Input.GetButtonUp("Crouch"))
        {
            // Set crouching false
            crouch = false;
        }
    }

    public void OnLanding()
    {
        // If landing, set jumping false and play the correct animation (Walking or Idle)
        animator.SetBool("IsJumping", false);
    }

     public void OnCrouching(bool isCrouching)
    {
        // If crouching play the crouching animation
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        //Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        // Set jumping false if not jumping
        jump = false;
    }
}
