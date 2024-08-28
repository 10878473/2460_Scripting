using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Vector3Data : ScriptableObject
{
    public Vector3 vector3Value;
    
    public void UpdateVector3(float x, float y, float z)
    {
        vector3Value.x = x;
        vector3Value.y = y;
        vector3Value.z = z;
    }

    public void addDimensions(float x, float y, float z)
    {
        //negative values can be added as well
        vector3Value.x += x;
        vector3Value.y += y;
        vector3Value.z += z;
    }

    public void addSize(float number)
    {
        vector3Value.x += number;
        vector3Value.y += number;
        vector3Value.z += number;
    }

    public void addVector(Vector3 vector)
    {
        vector3Value.x += vector.x;
        vector3Value.y += vector.y;
        vector3Value.z += vector.z; 
    }
}
