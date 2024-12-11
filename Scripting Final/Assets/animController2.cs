using System.Collections;
using UnityEngine;

public class animController2 : MonoBehaviour
{
    // Animator and Parameters
    public Animator animator; // Reference to the Animator component

    // States
    public bool running, airborn, flying, idling, wasAirborn, isGrounded, canRay,canshoot;
    
    // Inputs
    private float inputFire;
    private float inputX;
    private float inputJump;
    private Vector3 rayStart;

    public CharacterController controller;
    public PlayerStats stats;
    public LayerMask groundMask; // Specify what layers are considered ground

    // Debug Variables
    public GameObject grounded, isRunning, idle, fire, landing;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        TakeInput();
        ChangeState();
        DisplayDebug();
    }

    void TakeInput()
    {
        inputX = Input.GetAxis("Horizontal");
        inputFire = Input.GetAxis("Fire1");
        inputJump = Input.GetAxis("Jump");
        airborn = !controller.isGrounded;

        rayStart = controller.transform.position + Vector3.down * (controller.height / 2 - 0.1f);

        // Check for ground using raycast
        if (canRay)
        {
            isGrounded = Physics.Raycast(rayStart, Vector3.down, 1f, groundMask);
        }
    }

    void DisplayDebug()
    {
        Debug.DrawRay(rayStart, Vector3.down * 1f, isGrounded ? Color.green : Color.red);

        grounded.SetActive(isGrounded);
        isRunning.SetActive(running);
        idle.SetActive(idling);
        fire.SetActive(inputFire != 0);
    }

    void ChangeState()
    {
        // Running state
        if (isGrounded && inputX != 0)
        {
            if (!running)
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isIdling", false);
                running = true;
                idling = false;
            }
        }

        // Idling state
        if (running && inputX == 0)
        {
            if (!idling)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdling", true);
                running = false;
                idling = true;
            }
        }

        // Jumping or Flying state
        if (inputJump != 0 && stats.isflying)
        {
            if (!wasAirborn)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdling", false);
                animator.SetBool("isJumping", true);

                running = false;
                idling = false;
                wasAirborn = true;
                canRay = false;

                StartCoroutine(JumpRayCooldown());
            }
        }

        // Landing state
        if (isGrounded && wasAirborn)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isLanding", true);

            wasAirborn = false;
            landing.SetActive(true);
            StartCoroutine(LandingCooldown());
        }

        // Shooting states
        if (idling && inputFire > 0)
        {
            animator.SetTrigger(canshoot ? "IdleShoot" : "CantShoot");
            if (canshoot) StartCoroutine(ShootingCooldown());
        }
        else if (running && inputFire > 0)
        {
            animator.SetTrigger(canshoot ? "RunShoot" : "CantShoot");
            if (canshoot) StartCoroutine(ShootingCooldown());
        }
        else if (airborn && inputFire > 0)
        {
            animator.SetTrigger(canshoot ? "FlyShoot" : "CantShoot");
            if (canshoot) StartCoroutine(ShootingCooldown());
        }
    }

    IEnumerator ShootingCooldown()
    {
        yield return new WaitForSeconds(1f);
        canshoot = true;
    }

    IEnumerator JumpRayCooldown()
    {
        yield return new WaitForSeconds(1.5f);
        canRay = true;
    }

    IEnumerator LandingCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        landing.SetActive(false);
        animator.SetBool("isLanding", false);
    }
}
