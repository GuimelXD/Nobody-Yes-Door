using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Balls", menuName = "ScriptableObjects/BallsManager", order = 2)]

public class BallsManager : ScriptableObject
{
    public GameObject[] ballsNameList;
}
