using UnityEngine;

public class CharacterSideScroller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float flightForce = 4f;
    public float gravity = -9.81f;
    public int maxFlight = 200;

    private CharacterController controller;
    private Vector3 velocity;
    public int flightRemaining;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        flightRemaining = maxFlight;
    }

    private void Update()
    {
        // Calling our methods to affect velocity
        HorizontalMovement();
        ApplyGravity();
        Fly();
        

        // Apply all movement
        controller.Move(velocity * Time.deltaTime);
        SetZPositionToZero();
    }

    private void HorizontalMovement()
    {
        var moveInput = Input.GetAxis("Horizontal");
        var moveDirection = new Vector3(moveInput, 0f, 0f) * moveSpeed;
        velocity.x = moveDirection.x;
    }

    private void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0;
            flightRemaining = maxFlight;
        }
    }

    private void Fly()
    {
        if (!Input.GetButton("Jump") || (!controller.isGrounded && flightRemaining <= 0)) return;
        if(velocity.y < flightForce){
            velocity.y += flightForce;
        }
        flightRemaining--;
    }

    private void SetZPositionToZero()
    {
       // gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
        
        var transform1 = gameObject.transform;
        var position = transform1.position;
        position.z = 0;
        transform1.position = position;
    }

    public void AddBounceVel(float vel)//can be called by the player, or by other scripts
    {
        velocity.y += vel * Time.deltaTime;
    }

    public void MegaBounce()// can be called by event systems
    {
        //Debug.Log("Player should be going up now");
        velocity.y += 30f;
    }

    public void MediumBounce()// bounce can be called by event systems
    {
        velocity.y += 15f * Time.deltaTime;
    }
}