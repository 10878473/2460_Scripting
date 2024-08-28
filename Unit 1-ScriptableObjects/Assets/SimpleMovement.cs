using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public PlayerStatsSO playerStats;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical")* playerStats.speed);
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal")* playerStats.speed);
        if (Input.GetKey(KeyCode.Space) && (transform.position.y < 2))
        {
            rb.AddForce(Vector3.up * .1f, ForceMode.Impulse);
        }
    }
}
