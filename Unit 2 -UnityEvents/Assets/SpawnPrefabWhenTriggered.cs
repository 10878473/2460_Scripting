using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabWhenTriggered : MonoBehaviour
{
    public GameObject prefab;
    
    public List<GameObject> spawnedObjects = new List<GameObject>();
    // Start is called before the first frame update
   
    public void spawnPrefab(){
        spawnedObjects.Add(Instantiate(prefab, transform.position, transform.rotation));
    }

    public void destroylast()
    {

        Destroy(spawnedObjects[spawnedObjects.Count - 1]);
    }
}
