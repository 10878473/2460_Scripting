using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancer : MonoBehaviour
{
    public GameObject prefab;
    private int countingNum=0;
    public void CreateInstance()
    {
        Instantiate(prefab);
    }

    public void CreateInstance(Vector3Data position)
    {
        Instantiate(prefab,position.value, Quaternion.identity);
    }

    public void CreateInstance(Vector3DataList positionslist)//Creates a instance at a random point from the list.
    {
        Instantiate(prefab,positionslist.Vector3Dlist[Random.Range(0,positionslist.Vector3Dlist.Count-1)].value, Quaternion.identity);
    }

    public void CreateAllInstancesInList(Vector3DataList positionslist)
    {
        foreach (Vector3Data position in positionslist.Vector3Dlist)
        {
            Instantiate(prefab,position.value, Quaternion.identity);
        }
    }
    public void CountAnInstanceFromList(Vector3DataList positionslist)
    {
        
        Instantiate(prefab,positionslist.Vector3Dlist[countingNum].value, Quaternion.identity);
        countingNum++;
        
        if (countingNum == positionslist.Vector3Dlist.Count)
        {
            countingNum= 0;
        }
    }
}
