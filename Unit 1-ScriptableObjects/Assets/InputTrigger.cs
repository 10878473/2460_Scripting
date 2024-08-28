using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputTrigger : MonoBehaviour
{
    public UnityEvent ButtonPressed;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A ButtonPressed");
            ButtonPressed.Invoke();

        }

    }
}
