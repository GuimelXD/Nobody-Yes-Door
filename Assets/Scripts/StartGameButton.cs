using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;
    [SerializeField] private string scene = null;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;
    private Vector3 newPlayerPos;

    public UnityEvent onPressed, onReleased;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
        newPlayerPos.Set(-15, 6, -15);
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

    private void LoadIt(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        GameObject.Find("Player").transform.position = newPlayerPos;
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        LoadIt(scene);
        Debug.Log("Pressed");
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
