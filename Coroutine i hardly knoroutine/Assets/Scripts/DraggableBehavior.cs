using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DraggableBehavior : MonoBehaviour
{
    public UnityEvent startDragEvent,endDragEvent;
    private Camera camObj;

    public bool draggable;

    public Vector3 position, offset;
    // Start is called before the first frame update
    void Start()
    {
        camObj = Camera.main;
    }

    public IEnumerator OnMouseDown()
    {
        offset = transform.position - camObj.ScreenToWorldPoint(Input.mousePosition);
        draggable = true;
        startDragEvent.Invoke();
        yield return new WaitForFixedUpdate();
        
        while (draggable)
        {
            yield return new WaitForFixedUpdate();
            position = camObj.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = position;
        }
    }

    private void OnMouseUp()
    {
        draggable = false;
        endDragEvent.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
