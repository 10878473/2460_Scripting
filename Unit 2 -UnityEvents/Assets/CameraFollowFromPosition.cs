using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFromPosition : MonoBehaviour
{
    public GameObject target;
    
    public Vector3 offsetPosition;
    public Vector3 backoutPosition;
    public Vector3 backOutBy;
    public bool following;
    
    // Start is called before the first frame update
    void Start()
    {
        following = true;
        offsetPosition =   transform.position -target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        if (following)
        {
            transform.position = target.transform.position + offsetPosition;
        }
    }

    public void Backout()
    {
        offsetPosition += backOutBy;
    }
    
}
