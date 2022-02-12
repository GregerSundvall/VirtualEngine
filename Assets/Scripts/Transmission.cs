using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Transmission : MonoBehaviour
{
    [SerializeField] private Engine _engine;
    [SerializeField] private int _currentGear = 2;

    private Gear[] _gears = new[]
    {
        new Gear("R", "", ""),
        new Gear("0", "", ""),
        new Gear("1", "2", ""),
        new Gear("2", "3", "1"),
        new Gear("3", "4", "2"),
        new Gear("4", "", "3"),
    };
    private float _inputRpm;
    private float _outputRpm;
    
    

    private void Start()
    {
        
    }

    private void Update()
    {
        if (_engine.Rpm > 5000)
        {
            if (_currentGear > 1 && _currentGear != _gears.Length - 1)
            {
                _currentGear++;
            }
        } else if (_engine.Rpm < 1500)
        {
            if (_currentGear > 2)
            {
                _currentGear--;
            }
        }
    }

    private class Gear {
        public Gear(string name, string next, string previous)
        {
            this.name = name;
            this.next = next;
            this.previous = previous;
        }
        public string name;
        public string next;
        public string previous;
    }
}
