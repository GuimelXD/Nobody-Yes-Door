using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RoomsPuzzlesManager", order = 1)]

public class RoomsPuzzlesManager : ScriptableObject
{
    public GameObject[] sceneNameList;
    public GameObject[] puzzleNameList;
}
