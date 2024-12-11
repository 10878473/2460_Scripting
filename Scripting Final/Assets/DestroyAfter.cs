using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    // similar to timed destroy behaviors, this one also has a cancel function, can be used for timed bombs or things that you want to be ablt oto sop from destroying themselves
    public float seconds = 2f;
    private WaitForSeconds wfs;
    private bool doDestroy = true;
    public IEnumerator startDestroy()
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
    public void StartCountdown()
    {
        StartCoroutine("startDestroy");
    }
}
