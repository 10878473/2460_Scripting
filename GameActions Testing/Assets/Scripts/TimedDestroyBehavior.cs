using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroyBehavior : MonoBehaviour
{
    public float seconds = 1f;
    private WaitForSeconds wfs;
    IEnumerator Start()
    {
        wfs = new WaitForSeconds(seconds);
        yield return wfs;
        Destroy(gameObject);
    }
}
