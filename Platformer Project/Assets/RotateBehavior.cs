using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehavior : MonoBehaviour
{
    public bool isSpinning;
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        if (isSpinning)
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }

    public void Spin()
    {
        isSpinning = true;
    }

    public void StopSpinning()
    {
        isSpinning = false;
    }
    
}
