using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IfLessthan0trigger : MonoBehaviour
{
    public IntData data;

    public UnityEvent isless0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waituntilTrigger());
    }

    // Update is called once per frame
    

    public IEnumerator waituntilTrigger()
    {
        yield return new WaitUntil(() => data.value <= 0);
        isless0.Invoke();
        Debug.Log("Data hit 0, event triggered");
    }
}
