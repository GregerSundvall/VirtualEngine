using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _steering;
    
    private Rigidbody _rigidbody;
    private Transform _transform;

    private float _maxSpeed = 80;
    private float _minSpeed = -10;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    public float Speed
    {
        get => _speed;
        set => _speed = Mathf.Clamp(value, _minSpeed, _maxSpeed);
    }

    public float Steering
    {
        get => _steering;
        set => _steering = Mathf.Clamp(value, -1, 1);
    }



    void Update()
    {
        SetSpeed();
        SetVelocity();
        SetSteering();
        SetAngle();
    }
    
    private void SetAngle()
    {
        _transform.Rotate(Vector3.up, Steering * (_rigidbody.velocity.magnitude / _maxSpeed));
    }
    
    private void SetVelocity()
    {
        _rigidbody.velocity = _transform.forward * Speed;
    }
    
    public void SetSpeed()
    {
        if (Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -0.1f)
        {
            Speed += Input.GetAxis("Vertical") * 0.4f;

        }
        else
        {
            Speed = Mathf.MoveTowards(Speed, 0, 0.4f);
        }
    }
    
    public void SetSteering()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Steering = Input.GetAxis("Horizontal");
        }
        else
        {
            Steering = Mathf.MoveTowards(Steering, 0, 0.1f);
        }
    }
}
