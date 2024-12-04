using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    // The direction to move in
    public Vector3 direction = Vector3.forward;

    // The speed of movement
    public float speed = 5f;

    // Internal flag to track if movement is active
    private bool isMoving = false;

    void Update()
    {
        // If the object is set to move, update its position
        if (isMoving)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }

    // Public method to start moving the object
    public void Go()
    {
        isMoving = true;
    }

    // Optional method to stop movement
    public void Stop()
    {
        isMoving = false;
    }
}