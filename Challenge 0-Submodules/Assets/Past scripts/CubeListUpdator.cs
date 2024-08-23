using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CubeListUpdator : MonoBehaviour
{
    // Start is called before the first frame update
    //visual indicator in a TMP text box can be updated easily
    public TMP_Text text;
    public int cubeList;
    public GameObject cubeSwarm;//this is currently unused, I may use a list of all cubes in play to do interesting things to them
    void Start()
    {
        cubeList = 0;
        cubeSwarm = GameObject.Find("CubeSwarm");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //put this on a empty gameobject, i usually use a GameController gameobject.
    //other scripts that create cubes can use this to add up the amount of cubes in the scene
    public void AddCube(){
        cubeList ++;
        text.text = "Cubes: " + cubeList.ToString();
    }
    public void RemoveCube(){
        cubeList --;
        text.text = "Cubes: " + cubeList.ToString();
    }
}
