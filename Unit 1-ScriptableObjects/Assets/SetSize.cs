
using UnityEngine;

public class SetSize : MonoBehaviour
{
    public DataFloat sizePercent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(sizePercent.value,sizePercent.value,sizePercent.value);
    }
}
