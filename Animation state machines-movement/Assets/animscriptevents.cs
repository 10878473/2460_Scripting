using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class animscriptevents : MonoBehaviour
{
    // Unity Events for animations
    public UnityEvent SwapEvent, RunEvent, IdleEvent, JumpEvent, FlyEvent, JumpLandEvent, FlyLandEvent, DeathEvent;

    // Public variables
    public bool canFly = false; // Boolean to enable flying
    public PlayerStats playerStats; // Reference to PlayerStats script

    // Private variables
    private bool isJumping = false;
    private bool isRunning = false;

    // Reference to CharacterController
    private CharacterController characterController;

    void Start()
    {
        // Get the CharacterController component
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        HandleJumpAndFly();
    }

    private void HandleMovement()
    {
        bool isMovingHorizontally = Input.GetAxis("Horizontal") != 0;
        bool isMovingVertically = Input.GetAxis("Vertical") != 0;

        if (isMovingHorizontally || isMovingVertically)
        {
            if (!isRunning && isMovingHorizontally) // Trigger RunEvent only once per new horizontal movement
            {
                Debug.Log("PlayerMoving");
                RunEvent.Invoke();
                isRunning = true;
            }
        }
        else
        {
            if (isRunning) // Return to idle if no input is detected
            {
                Debug.Log("PlayerIdle");
                IdleEvent.Invoke();
                isRunning = false;
            }
        }

        // Handle Swap input
        if (Input.GetAxis("Swap") != 0)
        {
            Debug.Log("PlayerSwapping");
            SwapEvent.Invoke(); // Trigger SwapEvent
        }
    }

    private void HandleJumpAndFly()
    {
        // Check if the player is grounded
        bool isGrounded = IsGrounded();

        // Handle flying
        if (playerStats != null && playerStats.isflying)
        {
            if (canFly && !isJumping)
            {
                Debug.Log("PlayerFlying");
                FlyEvent.Invoke(); // Trigger FlyEvent
                isJumping = false; // Reset jumping state since we are flying
            }
        }
        else
        {
            // Handle regular jumping
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Debug.Log("PlayerJumping");
                JumpEvent.Invoke(); // Trigger JumpEvent
                isJumping = true;
            }

            // Landing logic for regular jumping
            if (isJumping && isGrounded)
            {
                Debug.Log("PlayerLanded");
                JumpLandEvent.Invoke(); // Trigger JumpLandEvent
                isJumping = false;
            }
        }

        // Handle flying landing
        if (canFly && !isGrounded && !playerStats.isflying)
        {
            Debug.Log("PlayerFlyLanded");
            FlyLandEvent.Invoke(); // Trigger FlyLandEvent
        }
    }

    // Helper function to check if the player is grounded
    private bool isGroundedCached = false; // Cached value for grounded status
    private bool isCheckingGround = false; // Prevent multiple checks during delay

    private bool IsGrounded()
    {
        if (!isCheckingGround)
        {
            StartCoroutine(CheckGroundWithDelay());
        }
        return isGroundedCached;
    }

    private IEnumerator CheckGroundWithDelay()
    {
        isCheckingGround = true; // Prevents overlapping checks
        yield return new WaitForSeconds(0.5f); // Wait for half a second

        float rayLength = 1.5f; // Length of the ray
        Vector3 rayOrigin = transform.position; // Start of the ray
        Vector3 rayDirection = Vector3.down; // Direction of the ray

        // Perform the raycast and ignore the CharacterController
        if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hitInfo, rayLength))
        {
            if (hitInfo.collider != characterController)
            {
                isGroundedCached = true;
            }
            else
            {
                isGroundedCached = false;
            }
        }
        else
        {
            isGroundedCached = false;
        }

        // Visualize the raycast
        Debug.DrawRay(rayOrigin, rayDirection * rayLength, isGroundedCached ? Color.green : Color.red);

        if (isGroundedCached)
        {
            Debug.Log("Raycast hit: Ground detected");
        }

        isCheckingGround = false; // Ready for the next check
    }
}
