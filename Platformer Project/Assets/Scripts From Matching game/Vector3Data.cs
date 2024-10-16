using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;
    public void moveObjecttoValue(GameObject obj){
        obj.transform.position = value;
        Debug.Log(obj.name + " moved to " + obj.transform.position);
    }

    public void moveCharactertoPoint(GameObject obj)
    {   
        //Special method required for character controllers as they override obj position. 
        obj.GetComponent<CharacterController>().enabled = false;
        obj.transform.position = value;
        obj.GetComponent<CharacterController>().enabled = true;
    }
}
