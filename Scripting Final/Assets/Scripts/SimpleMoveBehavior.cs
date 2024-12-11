using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveBehavior : MonoBehaviour
{
    public float speed = 4f;
    public Vector3 direction = Vector3.down;
    
    private bool stop = true;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (!stop)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void start()
    {
        stop = false;
    }

    public void stopmoving()
    {
        stop = true;
    }

    public void reset()
    {
        stop = true;
        transform.position = startPos;
    }

}
