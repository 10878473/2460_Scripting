using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPillar : MonoBehaviour
{
    // Start is called before the first frame update
    //need to have a cube prefab with CubeGang.cs Script attached for this script to work properly.
    public GameObject swarmPrefab;
    private float spawninterval = 1f;
    public GameObject GameController;
    void Start()
    {
        GameController = GameObject.Find("GameController");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake(){
        InvokeRepeating("SpawnCube", 1, spawninterval);
    }
    void SpawnCube(){
        //instantiates a new cube above the piller 
        var newcube = Instantiate(swarmPrefab, transform.position + new Vector3(0,6,0), transform.rotation,swarmPrefab.transform);
        newcube.GetComponent<CubeGang>().isAlive = true;
        //set it to be able to move - ^^^ Change this variable if you dont want it immediately active
        
        // if the gamecontroller has the cube list script, update amount of cubes.
        try
        {
            GameObject.Find("GameConrtroller").GetComponent<CubeListUpdator>().AddCube();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
