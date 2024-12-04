using UnityEngine;

public class SimpleLaser : MonoBehaviour
{
    public Transform target; // Assign the target object in the Inspector
    public float rotationSpeed = 5f; // Speed of rotation
    private Vector3 originalScale; // To store the initial scale of the object

    void Start()
    {
        // Save the original scale of the object
        originalScale = transform.localScale;
    }

    void Update()
    {
        // This script will wait for the specified input methods to be called.
        // Rotate towards the target in a method, not continuously.
    }

    public void Target()
    {
        if (target != null)
        {
            
            // Instantly rotate towards the target
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = lookRotation;
            
        }
        else
        {
            Debug.LogWarning("Target is not assigned!");
        }
    }

    public void Fire()
    {
        // Increase the scale on the x-axis
        Vector3 newScale = transform.localScale;
        //newScale.z = 10f;
        newScale.y = 2f;
        newScale.x = 2f;
        transform.localScale = newScale;
    }

    public void Cooldown()
    {
        // Reset the scale to the original scale
        transform.localScale = originalScale;
    }
}
