using UnityEngine;
using UnityEngine.Events;
public class CharacterSideScroller : MonoBehaviour
{
    
    public float gravity = -9.81f;
    private CharacterController controller;
    private Vector3 velocity;
    public UnityEvent playerjumped,playerlanded,playerdoublejumped;
    public PlayerStats stats;
    private int jumpsremaining;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        stats.flightleft = stats.maxFlight;
        jumpsremaining = stats.maxJumps;
        
    }

    private void Update()
    {
        // Calling our methods to affect velocity
        HorizontalMovement();
        ApplyGravity();
        if (stats.isflying == true)
        {
            Fly();
        }
        else
        {
            Jump();
        }
        

        // Apply all movement
        controller.Move(velocity * Time.deltaTime);
        SetZPositionToZero();
        checkFlyChange();
    }
    
    private void HorizontalMovement()
    {
        var moveInput = Input.GetAxis("Horizontal");
        var moveDirection = new Vector3(moveInput, 0f, 0f) * stats.speed;
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
            stats.flightleft = stats.maxFlight;
            jumpsremaining = stats.maxJumps;
        }
    }

    public void checkFlyChange()
    {
        if (Input.GetAxis("Swap")>0)
        {
            if (stats.isflying == true)
            {
                stats.isflying = false;
            }
            else
            {
                stats.isflying = true;

            }
        }
    }
    private void Fly()
    {
        if (!Input.GetButton("Jump") || (!controller.isGrounded && stats.flightleft <= 0)) return;
        if(velocity.y < stats.flightpower){
            velocity.y += stats.flightpower;
        }
        stats.flightleft--;
    }
    private void Jump()
    {
        if (!Input.GetButtonDown("Jump") || (!controller.isGrounded && jumpsremaining <= 0)) return;
        if(velocity.y < stats.jumpHeight){
            velocity.y += stats.jumpHeight;
            playerjumped.Invoke();
        }
        jumpsremaining--;
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