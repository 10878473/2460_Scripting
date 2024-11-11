using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ColorIDList : ScriptableObject
{
    public List<ColorID> colorIDs;
    private int num;
    public ColorID currentColor;

    public void randomizeCurrentColor()
    {
        num = Random.Range(0, colorIDs.Count);
        
        
        currentColor = colorIDs[num];
    }
}
