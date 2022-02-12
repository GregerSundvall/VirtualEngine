using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] private bool _isRunning = true;
    
    private float _rpm;
    private float _idleRpm = 800;
    private float _maxRpm = 6000;
    private float _torque;
    private float _throttleInput;
    private float _inputToRpmModifier = 5000;
    private float _rpmFalloff = 7000;

    public float Torque
    {
        get => Mathf.RoundToInt(_torque);
        set => _torque = value;
    }
    

    public float Rpm
    {
        get => Mathf.RoundToInt(_rpm);
        set => _rpm = Mathf.Clamp(value, _idleRpm, _maxRpm);
    }

    private void Update()
    {
        GetThrottleInput();
    }
    
    private void GetThrottleInput()
    {
        if (!_isRunning) return;
        
        _throttleInput = Input.GetAxis("Vertical");
        
        var modifiedInput = _throttleInput * _inputToRpmModifier;
        
        if (_throttleInput > 0)
        {
            Rpm += modifiedInput * Time.deltaTime;
        }
        else
        {
            Rpm -= _rpmFalloff * Time.deltaTime;
        }

        var rpmToTorqueModifier = Rpm / _maxRpm;
        Torque = Rpm * 0.1f * rpmToTorqueModifier;
    }
    
    
}
