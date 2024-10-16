using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vector3DataList : ScriptableObject
{
    public List<Vector3Data>Vector3Dlist;

    public Vector3Data GetVector3Data(int id)
    {
        return Vector3Dlist[id];
    }
    public Vector3Data GetRandom()
    {
        return Vector3Dlist[Random.Range(0,Vector3Dlist.Count)];
    }
}
