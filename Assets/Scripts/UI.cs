using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _torque;
    [SerializeField] private Engine _engine;
    
    
    void Update()
    {
        _torque.text = _engine.Torque.ToString();
    }
}
