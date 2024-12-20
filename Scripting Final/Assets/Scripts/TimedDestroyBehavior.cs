using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroyBehavior : MonoBehaviour
{
    public float seconds = 1f;
    private WaitForSeconds wfs;
    private bool doDestroy = true;
    IEnumerator Start()
    {
        wfs = new WaitForSeconds(seconds);
        yield return wfs;
        if (doDestroy)
        {
            Destroy(gameObject);

        }
    }

    public void dontDestroy()
    {
        doDestroy = false;
    }
}
