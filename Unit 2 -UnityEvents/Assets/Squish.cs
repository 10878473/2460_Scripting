using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Squish : MonoBehaviour
{
    public bool squished = false;

    public UnityEvent squishedEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "hammer" && !squished)
        {
            squished = true;
            if (this.gameObject.tag == "hammer")
            {
                transform.localScale = new Vector3(.75f,1f,0.25f);
                squishedEvent.Invoke();
            }
            else
            {
                squishedEvent.Invoke();
                transform.localScale = new Vector3(1f,0.25f,1f);
            }
        }
    }
}
