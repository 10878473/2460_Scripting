
using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBehavior : MonoBehaviour
{
    public UnityEvent TriggerEnterEvent;
    
    //when the gameobject collides with another gameobject - trigger something from a scriptableobject
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggering event, gameobject "+ gameObject.name + "triggered from collider "+ other.gameObject.name);
        TriggerEnterEvent.Invoke();
    }

    /*private void OnCollisionEnter(Collision other)
    {
        Debug.Log(gameObject.name + "collided with collision "+ other.gameObject.name);
        TriggerEnterEvent.Invoke();
    }*/
}
