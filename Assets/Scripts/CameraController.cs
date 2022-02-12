using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject car;

    private Rigidbody _carRB;
    private CarController _carController;
    private Vector3 _offsetPosition = new Vector3(0, 2, 0);
    private float _xOffset;
    private float _xMinOffset = 0;
    private float _xMaxOffset = 2;
    private float _zOffset;
    private float _zMinOffset = 0;
    private float _zMaxOffset = 2;
    
    
    private void Awake()
    {
        _carRB = car.GetComponent<Rigidbody>();
        _carController = car.GetComponent<CarController>();
    }

    private void Update()
    {
        SetOffsetPosition();
        
        transform.rotation = car.transform.rotation;
        transform.position = car.transform.TransformPoint(GetOffsetPosition());
        
    }
    
    public void SetOffsetPosition()
    {
        _xOffset = Mathf.MoveTowards(_xOffset, -_carController.Steering, 0.02f);
        _zOffset = -1.5f + -_carRB.velocity.magnitude * 0.02f;
    }
    
    private Vector3 GetOffsetPosition()
    {
        _offsetPosition.x = _xOffset;
        _offsetPosition.z = _zOffset;
        return _offsetPosition;
    }

}
