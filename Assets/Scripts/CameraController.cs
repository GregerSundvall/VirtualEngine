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
        _zOffset = -1.5f + -_carRB.velocity.magnitude * 0.02f;
        _offset.z = _zOffset;

        _xOffset = Mathf.MoveTowards(_xOffset, -_carController.Steering, 0.02f);
        _offset.x = _xOffset;
    }
    
    

}
