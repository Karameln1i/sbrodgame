using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyPressed;
    private float horizontalInput;
    private Rigidbody rigBodyComponent;
    [SerializeField] private Transform groundCheckTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        rigBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (jumpKeyPressed)
        {
            rigBodyComponent.AddForce(Vector3.up*5, ForceMode.VelocityChange);
            jumpKeyPressed = false;
        }
        rigBodyComponent.velocity = new Vector3(horizontalInput*3, rigBodyComponent.velocity.y, 0);
    }
}
