using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class animcontrollerscript : MonoBehaviour
{
    public UnityEvent Run, Idle, runshoot, jump, land, flyshoot, idleshoot, cantshoot;

    public bool running, airborn, flying, canshoot, idling;
    public CharacterController controller;
    //private float inputy;
    private float inputfire;
    private float inputx;
    private float inputJump;
    public PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        inputx = Input.GetAxis("Horizontal");
        //inputy = Input.GetAxis("Vertical");
        inputfire = Input.GetAxis("fire1"); 
        inputJump = Input.GetAxis("Jump");
        airborn = !controller.isGrounded;
        if (!airborn && inputx != 0)
        {
            if (!running)
            {
                Run.Invoke();
                running = true;
            }
        }
        if (running && inputx != 0)
        {
            if (!idling)
            {
                running = false;
                idling = true;
                Idle.Invoke();
            }
        }

        if (!airborn && inputJump >0)
        {
            airborn = true;
            jump.Invoke();
            

        }

        if (idling && inputfire > 0 )
        {
            if (canshoot)
            {
                canshoot = false;
                idleshoot.Invoke();
                cooldown();
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
                cooldown();
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
                cooldown();
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
        
}
    

