using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteBehavior : MonoBehaviour
{
    private SpriteRenderer rendererObj;
    private void Awake()
    {
        rendererObj = GetComponent<SpriteRenderer>();
    }

    public void ChangeRendererColor(ColorID obj)
    {
        rendererObj.color = obj.value;
    }
    public void ChangeRendererColor(ColorIDList obj)
    {
        rendererObj.color = obj.currentColor.value;
    }

    /*public void RandomizeFromListColor(ColorIDList obj)
    {
        rendererObj.color = obj.colorIDs[Random.Range(0,obj.colorIDs.Count -1)].value;
    }*/
}