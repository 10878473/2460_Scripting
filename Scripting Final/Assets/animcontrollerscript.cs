using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class animcontrollerscript : MonoBehaviour
{
    
    //   USED VARIABLES
    public UnityEvent Run, Idle, runshoot, jump, land, flyshoot, idleshoot, cantshoot;

    public bool running, airborn, flying, canshoot, idling,wasairborn, isGrounded, canray;
    public CharacterController controller;
    //private float inputy;
    private float inputfire;
    private float inputx;
    private float inputJump;
    private Vector3 rayStart;
    
    public PlayerStats stats;
    public LayerMask groundMask; // Specify what layers are considered ground

    //DEBUG VARIABLES
    public GameObject grounded, isrunning, idle, fire, landing;
    //
    
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        ChangeState();
        DisplayDebug();
    }
    void TakeInput()
    {
        inputx = Input.GetAxis("Horizontal");
        //inputy = Input.GetAxis("Vertical");
        inputfire = Input.GetAxis("Fire1"); 
        inputJump = Input.GetAxis("Jump");
        airborn = !controller.isGrounded;
        // Define the point slightly below the character
        rayStart = controller.transform.position + Vector3.down * (controller.height/2 - .1f);
        // Raycast downwards to check for ground
        if (canray)
        {
                    isGrounded = Physics.Raycast(rayStart, Vector3.down, 1f, groundMask);

        }
        
    }

    void DisplayDebug()
    {
        Debug.DrawRay(rayStart, Vector3.down * 1f, isGrounded ? Color.green : Color.red);
        //Debug.Log("Is Grounded: " + isGrounded);
        if (isGrounded)
        {
            grounded.SetActive(true);
        }
        else
        {
            grounded.SetActive(false);
        }
        if (running)
        {
            isrunning.SetActive(true);
        }
        else
        {
            isrunning.SetActive(false);
        }
        if (idling)
        {
            idle.SetActive(true);
        }
        else
        {
            idle.SetActive(false);
        }
        if (inputfire != 0)
        {
            fire.SetActive(true);
        }
        else
        {
            fire.SetActive(false);
        }
        
    }

    void ChangeState()
    {
        if (isGrounded && inputx != 0)// if on the ground and movement keys are pressed, run.
        {
            if (!running)
            {
                Run.Invoke();
                running = true;
                idling = false;
                //Debug.Log("Running");
            }
        }
        if (running && inputx == 0)
        {
            if (!idling)
            {
                running = false;
                idling = true;
                //Debug.Log("idling");
                
                Idle.Invoke();
            }
        }

        /*if (isGrounded && inputJump !=0 && (running || idling))
        {
            // If player was on the ground, then jumps, do jump anim. 
            if (!wasairborn)
            {
                wasairborn = true;
                jump.Invoke();
            }
            
        }*/
        
        if (inputJump !=0 && stats.isflying)
        {
            // If player was on the ground, then jumps, do jump anim.
            if (!wasairborn)
            {
                running = false;
                idling = false;
                wasairborn = true;
                canray = false;
                
                StartCoroutine("jumpraycool");
                
                jump.Invoke();
            }

        }

        if (isGrounded && wasairborn)
        {
            //Debug.Log("LANDING");
            wasairborn = false;
            land.Invoke();
            landing.SetActive(true);
            StartCoroutine("landgoway");
        }

        if (idling && inputfire > 0 )
        {
            if (canshoot)
            {
                canshoot = false;
                idleshoot.Invoke();
                StartCoroutine("cooldown");

            }
            else
            {
                cantshoot.Invoke();

            }
        }
        if (running && inputfire > 0)
        {
            if (canshoot)
            {
                canshoot = false;
                runshoot.Invoke();
                StartCoroutine("cooldown");
            }
            else
            {
                cantshoot.Invoke();

            }
        }
        if (airborn && inputfire > 0)
        {
            if (canshoot)
            {
                canshoot = false;
                flyshoot.Invoke();
                StartCoroutine("cooldown");
            }
            else
            {
                cantshoot.Invoke();

            }
        }
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(1f);
        canshoot = true;
    }

    IEnumerator jumpraycool()
    {
        yield return new WaitForSeconds(1.5f);
        canray = true;
    }

    IEnumerator landgoway()
    {
        yield return new WaitForSeconds(.5f);
        landing.SetActive(false);
    }
        
}
    

