using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    private float threshold = 0.1f;
    private float deadZone = 0.025f;
    public GameObject[] sceneNameList;
    private bool _isPressed;
    private Vector3 _startPos;
    private Vector3 Pos;
    private ConfigurableJoint _joint;
    private int RandomOption;
    private int aux = 1;

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

    public void LoadIt()
    {
        Destroy(GameObject.Find("sala"));
        Destroy(GameObject.Find("Point Light"));
        for (int z = 0; z >= -40; z -= 10)
        {
            for (int x = 0; x >= -40; x -= 10)
            {
                Pos.Set(x, 0, z);
                RandomOption = UnityEngine.Random.Range(0, sceneNameList.Length);
                SpawnRoom(sceneNameList[RandomOption], Pos);

                aux++;
            }
        }
        Destroy(GameObject.Find("Menu"));
    }

    private void SpawnRoom(GameObject nome, Vector3 Pos)
    {
        GameObject new_sala = Instantiate(nome, Pos, Quaternion.identity);
        new_sala.name = "sala." + aux;
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
