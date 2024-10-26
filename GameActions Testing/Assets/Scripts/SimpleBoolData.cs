using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class SimpleBoolData : ScriptableObject
{
    public bool Value;
    
    public UnityEvent OnValueChanged, TrueEvent, FalseEvent;
    
    //change value
    public void MakeTrue()
    {
        OnValueChanged.Invoke();
        TrueEvent.Invoke();
        Value = true;
    }

    public void MakeFalse()
    {
        OnValueChanged.Invoke();
        FalseEvent.Invoke();
        Value = false;
    }
}
