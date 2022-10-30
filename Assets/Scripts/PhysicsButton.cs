﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;
    [SerializeField] private Animator myPanel = null;
    [SerializeField] private string panel = null;
    [SerializeField] private Animator myPanel2 = null;
    [SerializeField] private string panel2 = null;
    [SerializeField] private Animator myPanel3 = null;
    [SerializeField] private string panel3 = null;
    [SerializeField] private Animator myPanel4 = null;
    [SerializeField] private string panel4 = null;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent onPressed, onReleased;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Math.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value,-1f,1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        myPanel.Play(panel, 0, 0.0f);
        myPanel2.Play(panel2, 0, 0.0f);
        myPanel3.Play(panel3, 0, 0.0f);
        myPanel4.Play(panel4, 0, 0.0f);
        Debug.Log("Pressed");
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
