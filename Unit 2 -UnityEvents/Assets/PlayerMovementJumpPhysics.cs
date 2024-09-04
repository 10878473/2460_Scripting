using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementJumpPhysics : MonoBehaviour
{
    public float Speed;
    public bool canJump;
    private Rigidbody rb ;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Speed * Vector3.forward * Time.deltaTime*Input.GetAxis("Vertical"));
        transform.Translate(Speed * Vector3.right * Time.deltaTime*Input.GetAxis("Horizontal"));

        if (Input.GetAxis("Jump") != 0f)
        {
            if (canJump)
            {
                rb.AddForce(Vector3.up * 5f, ForceMode.VelocityChange);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //potentially add some if statements for collision tags
        canJump = true;
    }

    private void OnCollisionExit(Collision other)
    {
        canJump = false;
    }
}
