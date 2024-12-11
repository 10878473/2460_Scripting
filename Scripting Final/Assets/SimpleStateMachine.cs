using UnityEngine;

public class SimpleStateMachine : MonoBehaviour
{
    // Animator
    public Animator animator;

    // States
    private enum State
    {
        Idle,
        Running,
        Flying,
        IdleShoot,
        RunningShoot,
        FlyingShoot
    }

    private State currentState = State.Idle;
    private State previousState; // To store the state before shooting

    // Input variables
    private float inputX;
    private float inputJump;
    private bool inputFire;

    // References
    public CharacterController controller;
    public PlayerStats stats; // Assume this tracks if the player can fly

    // Shooting cooldown tracking
    //private bool isShooting = false;
    private float shootCooldownTime = 1f;
    private float shootCooldownTimer = 0f;

    void Start()
    {
        if (controller == null)
        {
            controller = GetComponent<CharacterController>();
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Initialize state
        ChangeState(State.Idle);
    }

    void Update()
    {
        TakeInput();
        HandleShootingCooldown();
        UpdateState();
    }

    void TakeInput()
    {
        inputX = Input.GetAxis("Horizontal");
        inputJump = Input.GetAxis("Jump");
        inputFire = Input.GetButtonDown("Fire1"); // Detect when the Fire1 button is pressed
    }

    void HandleShootingCooldown()
    {
        // Handle cooldown timer when in cooldown state
        if (shootCooldownTimer > 0)
        {
            shootCooldownTimer -= Time.deltaTime;
        }
    }

    void UpdateState()
    {
        // Prevent transitioning to shooting state during cooldown
        if (shootCooldownTimer > 0) return;

        if (inputFire)
        {
            // Transition to the appropriate shooting state based on the current state
            previousState = currentState; // Store the current state
            if (currentState == State.Running)
            {
                ChangeState(State.RunningShoot);
            }
            else if (currentState == State.Flying)
            {
                ChangeState(State.FlyingShoot);
            }
            else if (currentState == State.Idle)
            {
                ChangeState(State.IdleShoot);
            }
            return;
        }

        // Determine new state (normal idle, running, flying transitions)
        if (controller.isGrounded)
        {
            if (Mathf.Abs(inputX) > 0.1f)
            {
                ChangeState(State.Running);
            }
            else
            {
                ChangeState(State.Idle);
            }
        }
        else if (inputJump > 0 && stats.isflying)
        {
            ChangeState(State.Flying);
        }
    }

    void ChangeState(State newState)
    {
        if (currentState == newState) return; // Avoid unnecessary transitions

        // Exit current state
        ExitState(currentState);

        // Enter new state
        currentState = newState;
        EnterState(newState);
    }

    void ExitState(State state)
    {
        switch (state)
        {
            case State.Idle:
                animator.SetBool("isIdling", false);
                break;
            case State.Running:
                animator.SetBool("isRunning", false);
                break;
            case State.Flying:
                animator.SetBool("isFlying", false);
                break;
            case State.IdleShoot:
                animator.SetBool("isIdleShooting", false);
                break;
            case State.RunningShoot:
                animator.SetBool("isRunningShooting", false);
                break;
            case State.FlyingShoot:
                animator.SetBool("isFlyingShooting", false);
                break;
        }
    }

    void EnterState(State state)
    {
        switch (state)
        {
            case State.Idle:
                animator.SetBool("isIdling", true);
                break;
            case State.Running:
                animator.SetBool("isRunning", true);
                break;
            case State.Flying:
                animator.SetBool("isFlying", true);
                break;
            case State.IdleShoot:
                animator.SetBool("isIdleShooting", true);
                break;
            case State.RunningShoot:
                animator.SetBool("isRunningShooting", true);
                break;
            case State.FlyingShoot:
                animator.SetBool("isFlyingShooting", true);
                break;
        }

        // Shooting cooldown starts after shooting
        if (state == State.IdleShoot || state == State.RunningShoot || state == State.FlyingShoot)
        {
            shootCooldownTimer = shootCooldownTime; // Start cooldown timer
        }
    }
}
