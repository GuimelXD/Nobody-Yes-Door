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
    private bool _isPressed;
    private Vector3 _startPos;
    private Vector3 Pos;
    private ConfigurableJoint _joint;
    private int RandomOption;
    private int RandomOption2;
    private int instanceNumber = 1;

    public RoomsPuzzlesManager roomsPuzzlesManager;

    public UnityEvent onPressed, onReleased;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
        LoadIt();
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
                RandomOption = UnityEngine.Random.Range(0, roomsPuzzlesManager.sceneNameList.Length);
                RandomOption2 = UnityEngine.Random.Range(0, roomsPuzzlesManager.puzzleNameList.Length);
                SpawnRoom(roomsPuzzlesManager.sceneNameList[RandomOption]/*sceneNameList[RandomOption]*/, Pos);
                SpawnPuzzle(roomsPuzzlesManager.puzzleNameList[RandomOption2], Pos);
                instanceNumber++;
            }
        }
        Destroy(GameObject.Find("Menu"));
    }

    private void SpawnRoom(GameObject nome, Vector3 Pos)
    {
        GameObject new_sala = Instantiate(nome, Pos, Quaternion.identity);
        int doorNumber = 0;
        for (int i = 0; i< new_sala.transform.childCount; i++)
        {
            if (new_sala.transform.GetChild(i).name == "sala")
            {
                new_sala.transform.GetChild(i).name = "sala." + instanceNumber;
                for (int j = 0; j < new_sala.transform.GetChild(i).childCount; j++)
                {
                    if (new_sala.transform.GetChild(i).GetChild(j).name == "door")
                    {
                        doorNumber++;
                        new_sala.transform.GetChild(i).GetChild(j).name = new_sala.transform.GetChild(i).GetChild(j).name + "." + instanceNumber + "." + doorNumber;
                    }                    
                }                
            }
        }
        //Debug.Log(new_sala.transform.GetChild(0).name);
        //string roomNumber = new_sala.name.Substring(new_sala.name.LastIndexOf('.') + 1);
        //Debug.Log(new_sala);
    }

    private void SpawnPuzzle(GameObject nomePuzzle, Vector3 Pos)
    {
        GameObject newPuzzle = Instantiate(nomePuzzle, Pos, Quaternion.identity);
        newPuzzle.name = nomePuzzle.name + "." + instanceNumber;
        //string puzzleNumber = newPuzzle.name.Substring(newPuzzle.name.LastIndexOf('.') + 1);
        //Debug.Log(newPuzzle);
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
