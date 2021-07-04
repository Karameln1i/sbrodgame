using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    
    private Input _input;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _input=new Input();

        _input.Player.Jump.performed += ctx => Jump();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 derection = _input.Player.Move.ReadValue<Vector2>();
        
        Movement(derection);
    }

    private void Movement (Vector3 derection)
    {
        float scaleMoveSpeed = _speed * Time.deltaTime;
        
        Vector3 moveDerection=new Vector3(derection.x,0,derection.y);
        transform.position += moveDerection*scaleMoveSpeed;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up*_jumpForce);
    }
}
