using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFireSimple : MonoBehaviour
{
    public Vector3 FireOffset = new Vector3(0,-.5f,1);
    public GameObject prefabtoSpawn;
    private GameObject latestspwned;
    private bool canfire = true;
    float inputfire;
    // Start is called bffefore the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputfire = Input.GetAxis("Fire1");
        if (inputfire > 0 && canfire)
        {
            StartCoroutine("Fireball");
            StartCoroutine("Cooldown1s");
        }
    }
    
    IEnumerator Fireball()
    {
        //Debug.Log(prefabtoSpawn);
        yield return new WaitForSeconds(.8f);
        latestspwned = Instantiate(prefabtoSpawn, transform.position + FireOffset, Quaternion.identity);
        latestspwned.transform.rotation = transform.rotation;
    
    }

    IEnumerator Cooldown1s()
    {
        canfire = false;
        yield return new WaitForSeconds(1f);
        canfire = true;

    }
}
