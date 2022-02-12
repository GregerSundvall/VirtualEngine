using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [SerializeField] private Engine _engine;
    [SerializeField] private AudioMixer _audioMixer;

    private AudioSource _audioSource;
    // private float _pitchShifterIdle = 1.5f;
    // private float _pitchShifterMaxRpm = 0.5f;
    private float _pitchShifterBase = 1.7f;
    private float _rpmToPitchShifterModifier = 0.0002f;
    
    // private float _pitchIdle = 0.5f;
    // private float _pitchMaxRpm = 3.0f;
    private float _rpmToPitchModifier = 0.0008f;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        //_audioMixer.SetFloat("PitchShifter", _pitchShifterIdle);
    }

    void Update()
    {
        _audioSource.pitch = _engine.Rpm * _rpmToPitchModifier - 0.2f;
        //_audioMixer.SetFloat("PitchShifter", _pitchShifterBase - _rpmToPitchShifterModifier);
    }
}
