using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CoroutineBehavior : MonoBehaviour
{
    public UnityEvent startEvent, startCountEvent, repeatCountEvent, endCountEvent, repeatUntilFalseEvent;
    public int counterNum;
    public bool _canRun = true;
    public float seconds = 1f;
    private WaitForSeconds wfsObj;
    private WaitForFixedUpdate wfuObj;
    private int counterOrigina;
    public bool CanRun
    {
        get => _canRun;
        set => _canRun = value;
    }

    private void Start()
    {
        counterOrigina = counterNum;
        startEvent.Invoke();
        wfsObj = new WaitForSeconds(seconds);

    }

    public void StartCounting()
    {
        StartCoroutine(Counting());
    }
    private IEnumerator Counting()
    {
        counterNum = counterOrigina;
        wfuObj = new WaitForFixedUpdate();
        startCountEvent.Invoke();
        Debug.Log("Start from Coroutine script ran");
        yield return wfsObj;

        while (counterNum > 0)
        {
            repeatCountEvent.Invoke();
            counterNum--;
            yield return wfsObj;
            Debug.Log("run on start");
        }
        endCountEvent.Invoke();
    }

    public void StartRepeatUntilFalse()
    {
        CanRun = true;
        StartCoroutine(RepeatUntilFalse());
    }

    private IEnumerator RepeatUntilFalse()
    {
        yield return wfsObj;
        while (CanRun)
        {
            
            repeatUntilFalseEvent.Invoke();
            yield return wfsObj;
        }
    }
    
}
