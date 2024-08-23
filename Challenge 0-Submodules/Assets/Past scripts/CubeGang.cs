using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeGang : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject target;
    private float distToTarget;
    public Vector3 heading;
    public GameObject cam;
    //public InputAbilities InputAbilities;
    private float speed = 10f;
    public bool isAlive;
    public Color originalColor;
    public Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        //take original color to be able to change color for visual indication of being stuck
        originalColor = gameObject.GetComponent<Renderer>().material.color;

        rb = gameObject.GetComponent<Rigidbody>();
        
        //original intent is for a swarm of cubes to follow the player, this target can be changed easily
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {             
        
        heading = (target.transform.position - transform.position).normalized;

        distToTarget = Vector3.Distance(transform.position, target.transform.position);
        if( isAlive && (distToTarget > 15) /*&& InputAbilities.swarming == false && InputAbilities.forcing == false*/){
            rb.AddForce(heading * speed, ForceMode.Acceleration);

        }
        if (/*(InputAbilities.swarming == true) && */(distToTarget > 4) && isAlive/* && !InputAbilities.forcing*/)
        {
            //Debug.Log("REALLY SWARMING");
            rb.AddForce(heading*(speed*1.5f), ForceMode.Acceleration);

        }
        //if target is a player with a camera, this code will use their camera direction to force movement
        /*if (InputAbilities.forcing && isAlive && !InputAbilities.swarming)
        {
            //rb.AddForce(heading*9, ForceMode.Acceleration);
            rb.AddForce(cam.transform.forward*(speed*1.8f), ForceMode.Acceleration);
        }*/
        //if cube is stuck and far away, it will try to fix this by jumping. it shouldn't stay red unless truly stuck
        if(rb.velocity.magnitude < 1 && isAlive && (distToTarget > 20) /*&& !InputAbilities.forcing && !InputAbilities.swarming*/){
            
            rb.AddForce(Vector3.up*4, ForceMode.Impulse);
            gameObject.GetComponent<Renderer>().material.color = newColor;
        } else{gameObject.GetComponent<Renderer>().material.color = originalColor;}
    }
}