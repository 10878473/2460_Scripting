using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple3DMove : MonoBehaviour
{
    private Vector3 InputV3;
    public CharacterController controller;
    public bool constrainZ = false;
    public float speed = 5.0f;
    public Vector3 velocityV3 = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        GetInput();// get input, set velocity to input
        setZ(); //sets velocity of z to 0 if toggled
        addGravity(); // adds negative velocity if not on ground
        jump();//handles jump if statement
        move(); // moves player.
        
    }

    void setZ()
    {
        if (constrainZ == true)
        {
            velocityV3.z = 0f;
        }
    }

    void GetInput()
    {
        InputV3 = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        velocityV3 = InputV3;
    }

    void move()
    {
        controller.Move(velocityV3 * Time.deltaTime*speed);
    }

    void addGravity()
    {
        if (controller.isGrounded == false)
        {
            velocityV3.y -= 0.2f;
        }
        else
        {
            velocityV3.y = 0f;
        }
    }

    void jump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (controller.isGrounded)
            {
                velocityV3.y += 4f;
            }
        }
    }
}
