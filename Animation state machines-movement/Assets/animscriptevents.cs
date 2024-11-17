using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;

public class animscriptevents : MonoBehaviour
{
    //public List<KeyCode> leftKeys; //takes left input
    public UnityEvent SwapEvent, LeftEvent, RightEvent, JumpEvent, FlyEvent,JumpLandEvent, FlyLandEvent,DeathEvent;

    public bool movingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Debug.Log("PlayerMoving");
        }

        if (Input.GetAxis("Swap")!= 0)
        {
            Debug.Log("PlayerSwapping");
            //buttonpressed = true;
            
            SwapEvent.Invoke();
        }
        
        if (Input.GetAxis("Horizontal")>0)
        {
            Debug.Log("movingright");
        }
    }
}
