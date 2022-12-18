using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KeycardPuzzle : MonoBehaviour
{
    public GameObject keycardRed;
    public GameObject keycardGreen;
    public GameObject keycardBlue;
    public GameObject potRed;
    public GameObject potGreen;
    public GameObject potBlue;
    public Material materialGreen;
    public Material materialRed;
    public Material materialBranco;
    private GameObject[] spawnAnchors;
    private int RandomOption;
    private int points;
    private bool completed;

    private string stringPuzzleNumber;
    int puzzleNumber;
    RoomManager roomManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnAnchors = GameObject.FindGameObjectsWithTag("cardSpawn");
        SpawnCard(keycardRed);
        SpawnCard(keycardGreen);
        SpawnCard(keycardBlue);
        Debug.Log(gameObject.name);
        stringPuzzleNumber = string.Concat(gameObject.name.Where(char.IsDigit));
        puzzleNumber = int.Parse(stringPuzzleNumber);
        roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (points == 3 && !completed)
        {

            completed = true;
            Debug.Log("Concluido");
            roomManager.openDoors(stringPuzzleNumber, puzzleNumber);
        }
    }

    private void SpawnCard(GameObject name)
    {
        RandomOption = Random.Range(0, spawnAnchors.Length);
        GameObject newCard = Instantiate(name, spawnAnchors[RandomOption].transform.position, Quaternion.identity);
        newCard.name = name.name;
    }

    public void AddPoints()
    {
        points++;
    }
}
