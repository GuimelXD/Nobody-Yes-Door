using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazePuzzle : MonoBehaviour
{

    private string stringPuzzleNumber;
    int puzzleNumber;
    RoomManager roomManager;

    // Start is called before the first frame update
    void Start()
    {
        stringPuzzleNumber = string.Concat(gameObject.name.Where(char.IsDigit));
        puzzleNumber = int.Parse(stringPuzzleNumber);
        roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Verify(string collidingObject)
    {
        if (collidingObject == "JoeJeff")
        {
            Debug.Log("JoeJeff Concluido");
            roomManager.openDoors(stringPuzzleNumber, puzzleNumber);

        }
    }
}
