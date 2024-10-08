using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MatchBehavior : MonoBehaviour
{
    public ID idObj;
    public UnityEvent matchEvent, noMatchEvent, noMatchDelayedEvent;
    
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        var tempObj = other.GetComponent<IDContainerBehavior>();
        if (tempObj ==null)
        {
            yield break;
        }
        var otherID = tempObj.idObj;
        if (otherID == idObj)
        {
            matchEvent.Invoke();
            Debug.Log("Match MADE with " + other.name);
        }
        else
        {
            noMatchEvent.Invoke();
            yield return new WaitForSeconds(0.5f);
            noMatchDelayedEvent.Invoke();
        }
    }

    public void setID(ColorIDList ColorIDListObj)
    {
        idObj = ColorIDListObj.currentColor;

    }
   
}

