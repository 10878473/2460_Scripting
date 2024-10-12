using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple3DMove : MonoBehaviour
{
    private Vector3 InputV3;
    public CharacterController controller;

    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        move();
    }

    void GetInput()
    {
        InputV3 = new Vector3(Input.GetAxis("Horizontal"), -1, Input.GetAxis("Vertical"));
    }

    void move()
    {
        controller.Move(InputV3 * Time.deltaTime*speed);
    }
}
