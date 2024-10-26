using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private bool isFalling = false;
    public float speed = 2;
    public float time = 2f;
    public WaitForSeconds timetoDestroy;
    // Start is called before the first frame update
    void Start()
    {
        timetoDestroy = new WaitForSeconds(time);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            transform.Translate(Vector3.down * Time.deltaTime*speed);
        }
    }

    public void Fall()
    {
        isFalling = true;
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
         yield return timetoDestroy;
         Destroy(gameObject);
    }
}
