using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    Vector3 Pos;
    GameObject player;
    GameObject salaInicial;
    private int roomIndexNumber;
    private int puzzleIndexNumber;
    private int val;
    private int val2;
    private int instanceNumber = 1;
    public RoomsPuzzlesManager roomsPuzzlesManager;
    int roomNumber;
    bool botaoFinalUsed = false;
    public bool loadOnStart = false;
    public GameObject botaoFinal;
    public Text finishTimeText;
    public GameObject ConcluidoPanel;
    public AudioSource audioSource;
    public AudioClip clip;

    private float gameTime;
    private bool gameTimerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        salaInicial = GameObject.Find("sala");
        if (loadOnStart)
        {
            LoadMap();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTimerIsRunning)
        {
            gameTime += Time.deltaTime;
        }
    }

    public void LoadMap()
    {
        Destroy(GameObject.Find("Menu"));
        player.transform.position = new Vector3(0, .26f, 3.675f);
        for (int z = 0; z >= -40; z -= 10)
        {
            for (int x = 0; x >= -40; x -= 10)
            {
                Pos.Set(x, 0, z);
                roomIndexNumber = Random.Range(0, roomsPuzzlesManager.sceneNameList.Length);
                puzzleIndexNumber = Random.Range(0, roomsPuzzlesManager.puzzleNameList.Length);
                SpawnRoom(roomsPuzzlesManager.sceneNameList[roomIndexNumber], Pos);
                SpawnPuzzle(roomsPuzzlesManager.puzzleNameList[puzzleIndexNumber], Pos, roomsPuzzlesManager.sceneNameList[roomIndexNumber].name);
                instanceNumber++;
            }
        }
        gameTimerIsRunning = true;
    }

    private void SpawnRoom(GameObject nome, Vector3 Pos)
    {
        GameObject new_sala = Instantiate(nome, Pos, Quaternion.identity);
        int doorNumber = 0;
        for (int i = 0; i < new_sala.transform.childCount; i++)
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
    }

    private void SpawnPuzzle(GameObject nomePuzzle, Vector3 Pos, string nomeSala)
    {
        val = Random.Range(0,5);
        val2 = Random.Range(0, 6);
        if (instanceNumber == 25 && !botaoFinalUsed)
        {
            GameObject newPuzzle = Instantiate(botaoFinal, Pos, Quaternion.identity);
            newPuzzle.name = nomePuzzle.name + "." + instanceNumber;
        }
        else if (nomePuzzle.name == "BotaoFinal")
        {
            if (instanceNumber == 1 || instanceNumber == 2 || instanceNumber == 6)
            {
                while (nomePuzzle.name == "BotaoFinal")
                {
                    puzzleIndexNumber = Random.Range(0, roomsPuzzlesManager.puzzleNameList.Length);
                    nomePuzzle = roomsPuzzlesManager.puzzleNameList[puzzleIndexNumber];
                }
                GameObject newPuzzle = Instantiate(nomePuzzle, Pos, Quaternion.identity);
                newPuzzle.name = nomePuzzle.name + "." + instanceNumber;
            }
            else if (!botaoFinalUsed && val == val2)
            {
                GameObject newPuzzle = Instantiate(nomePuzzle, Pos, Quaternion.identity);
                newPuzzle.name = nomePuzzle.name + "." + instanceNumber;
                botaoFinalUsed = true;
            }
            else
            {
                while (nomePuzzle.name == "BotaoFinal")
                {
                    puzzleIndexNumber = Random.Range(0, roomsPuzzlesManager.puzzleNameList.Length);
                    nomePuzzle = roomsPuzzlesManager.puzzleNameList[puzzleIndexNumber];
                }
                GameObject newPuzzle = Instantiate(nomePuzzle, Pos, Quaternion.identity);
                newPuzzle.name = nomePuzzle.name + "." + instanceNumber;
            }
        }
        else
        {
            GameObject newPuzzle = Instantiate(nomePuzzle, Pos, Quaternion.identity);
            newPuzzle.name = nomePuzzle.name + "." + instanceNumber;
        }
    }

    public void openDoors(string stringPuzzleNumber, int puzzleNumber)
    {
        Door door1;
        Door door2;
        Door door3;
        Door door4;
        Door doorNorth;
        Door doorEast;
        Door doorSouth;
        Door doorWest;
                
        door1 = GameObject.Find("door." + puzzleNumber + ".1").GetComponent<Door>();
        door2 = GameObject.Find("door." + puzzleNumber + ".2").GetComponent<Door>();
        door3 = GameObject.Find("door." + puzzleNumber + ".3").GetComponent<Door>();
        door4 = GameObject.Find("door." + puzzleNumber + ".4").GetComponent<Door>();
        try
        {
            roomNumber = puzzleNumber + 5;
            doorNorth = GameObject.Find("door." + roomNumber + ".1").GetComponent<Door>();
            doorNorth.openDoor();
        }
        catch
        {

        }
        try
        {
            roomNumber = puzzleNumber + 1;
            doorEast = GameObject.Find("door." + roomNumber + ".2").GetComponent<Door>();
            doorEast.openDoor();
        }
        catch
        {

        }
        try
        {
            roomNumber = puzzleNumber - 5;
            doorSouth = GameObject.Find("door." + roomNumber + ".3").GetComponent<Door>();
            doorSouth.openDoor();
        }
        catch
        {

        }
        try
        {
            roomNumber = puzzleNumber - 1;
            doorWest = GameObject.Find("door." + roomNumber + ".4").GetComponent<Door>();
            doorWest.openDoor();
        }
        catch
        {

        }
        door1.openDoor();
        door2.openDoor();
        door3.openDoor();
        door4.openDoor();
        audioSource.PlayOneShot(clip);
    }

    public void EndGame()
    {
        player.transform.position = new Vector3(0, -7.31f, 0);
        System.TimeSpan formattedTime = System.TimeSpan.FromSeconds(gameTime);
        Debug.Log(formattedTime.ToString("hh':'mm':'ss"));
        finishTimeText.text = formattedTime.ToString("hh':'mm':'ss");
        ConcluidoPanel.SetActive(true);
    }
}
