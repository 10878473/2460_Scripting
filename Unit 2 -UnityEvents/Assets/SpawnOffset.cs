using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOffset : MonoBehaviour
{
    public GameObject spawnObject;
    public Vector3 spawnOffset;
    
    
    public void makewithoffset(float offsetx, float offsety, float offsetz)//WHY DOESNT THIS WORK? Normally you can pass parameters, but it wont work here.
    {
	    Instantiate(spawnObject, transform.position + new Vector3(offsetx,offsety,offsetz), transform.rotation);
        
    }

    public void spawn()
    {
        Instantiate(spawnObject, transform.position + spawnOffset, spawnObject.transform.rotation);
    }

    
    
}
