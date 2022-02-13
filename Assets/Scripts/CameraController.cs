using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject car;

    private Rigidbody _carRB;
    private CarController _carController;
    private Vector3 _offset = new Vector3(0, 1.5f, 0);
    private float _xOffset;
    private float _xMinOffset = 0;
    private float _xMaxOffset = 2;
    private float _zOffset;
    private float _zMinOffset = 0;
    private float _zMaxOffset = 2;

    private Vector3 _rotation;
    
    private void Awake()
    {
        _carRB = car.GetComponent<Rigidbody>();
        _carController = car.GetComponent<CarController>();
        _rotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        SetOffset();
        transform.position = car.transform.TransformPoint(_offset);
        transform.rotation = Quaternion.LookRotation(car.transform.position - transform.position);
    }
    
    private void SetOffset()
    {
        _offset.z = -1.5f + -_carRB.velocity.magnitude * 0.02f;

        _offset.x = Mathf.MoveTowards(_offset.x, -_carController.Steering, 0.02f);
    }
    
    private void SetOffsetOther()
    {
        _offset.z = -1.5f + -_carRB.velocity.magnitude * 0.02f;
        _offset.x = Mathf.MoveTowards(_xOffset, -_carController.Steering, 0.02f);
        _offset.x = car.transform.position.x + Mathf.Cos(0.1f) * (car.transform.position.x - transform.position.x) * _carController.Steering;

        // var offsetBase = -1.5f + -_carRB.velocity.magnitude * 0.02f;
        // var arc = 0.3f * offsetBase;
        // var radius = offsetBase;
        // var angle = arc / radius;
        // // Move calculation to 0,0
        // var v = transform.position - car.transform.position;
        // var x = v.x * Mathf.Cos(angle) + v.z * Mathf.Sin(angle);
        // var z = v.z * Mathf.Cos(angle) - v.x * Mathf.Sin(angle);
        // //Move back to correct center
        // var vb = new Vector3(x, 0, z) + car.transform.position;
        // _offset.x = vb.x;
        // _offset.z = vb.z;
    }
    
    

}
