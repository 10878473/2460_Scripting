using UnityEngine;

public class FlipTransformBehaviour : MonoBehaviour
{
    
    public float direction1 = 0, direction2 = 180;
    private void Update()
    {
        
        if ((Input.GetAxis("Horizontal")>0))
        {
            transform.rotation = Quaternion.Euler(0,direction1,0);
        }

        if (!(Input.GetAxis("Horizontal") < 0)) return;
        transform.rotation = Quaternion.Euler(0,direction2,0);
    }
}