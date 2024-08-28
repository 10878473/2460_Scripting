using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRectangle : MonoBehaviour
{
    public Vector3Data Dimensions;
    public PlayerStatsSO PlayerStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Dimensions != null){        
            transform.localScale = Dimensions.vector3Value;
        }
        else if (PlayerStats != null)
        {
            transform.localScale = PlayerStats.aura;
        }
    }
}
