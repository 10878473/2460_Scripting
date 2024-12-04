
using UnityEngine;

public class ColorIDBehavior : IDContainerBehavior
{
    public ColorIDList ColorIDListObj;

    private void Awake()
    {
        idObj = ColorIDListObj.currentColor;
    }
}
