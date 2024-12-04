using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerableMoveBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector3Data targetPos;
    public Vector3 startPos = new Vector3();
    private bool forwardOrBack;
    private bool go;
    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (go)
        {
            
            //transform.Translate(((targetPos.value - startPos)/10)*Time.deltaTime);
        }
    }
}