using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightsPuzzle : MonoBehaviour
{
    public GameObject[] lightButton;
    int randomValue;
    bool[] lightArray = new bool[9];
    public Material materialGreen;
    public Material materialRed;

    private string stringPuzzleNumber;
    int puzzleNumber;
    RoomManager roomManager;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            randomValue = Random.Range(0, 2);
            if (randomValue == 0)
            {
                lightArray[i] = false;
            }
            else
            {
                lightArray[i] = true;
            }
            ChangeColors(i);
        }
        stringPuzzleNumber = string.Concat(gameObject.name.Where(char.IsDigit));
        puzzleNumber = int.Parse(stringPuzzleNumber);
        roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Verify()
    {
        if (lightArray[0] &&
            lightArray[1] && 
            lightArray[2] && 
            lightArray[3] && 
            lightArray[4] && 
            lightArray[5] && 
            lightArray[6] && 
            lightArray[7] && 
            lightArray[8] )
        {
            Debug.Log("concluído");
            roomManager.openDoors(stringPuzzleNumber, puzzleNumber);
        }
    }

    void ChangeColors(int num)
    {
        if (!lightArray[num])
        {
            lightButton[num].GetComponent<MeshRenderer>().material = materialRed;
        }
        if (lightArray[num])
        {
            lightButton[num].GetComponent<MeshRenderer>().material = materialGreen;
        }
    }

    public void Pressed1()
    {
        lightArray[0] = !lightArray[0];
        lightArray[1] = !lightArray[1];
        lightArray[3] = !lightArray[3];
        ChangeColors(0);
        ChangeColors(1);
        ChangeColors(3);
        Verify();
    }

    public void Pressed2()
    {
        lightArray[0] = !lightArray[0];
        lightArray[1] = !lightArray[1];
        lightArray[2] = !lightArray[2];
        lightArray[4] = !lightArray[4];
        ChangeColors(0);
        ChangeColors(1);
        ChangeColors(2);
        ChangeColors(4);
        Verify();
    }

    public void Pressed3()
    {
        lightArray[1] = !lightArray[1];
        lightArray[2] = !lightArray[2];
        lightArray[5] = !lightArray[5];
        ChangeColors(1);
        ChangeColors(2);
        ChangeColors(5);
        Verify();
    }

    public void Pressed4()
    {
        lightArray[0] = !lightArray[0];
        lightArray[3] = !lightArray[3];
        lightArray[4] = !lightArray[4];
        lightArray[6] = !lightArray[6];
        ChangeColors(0);
        ChangeColors(3);
        ChangeColors(4);
        ChangeColors(6);
        Verify();
    }

    public void Pressed5()
    {
        lightArray[1] = !lightArray[1];
        lightArray[3] = !lightArray[3];
        lightArray[4] = !lightArray[4];
        lightArray[5] = !lightArray[5];
        lightArray[7] = !lightArray[7];
        ChangeColors(1);
        ChangeColors(3);
        ChangeColors(4);
        ChangeColors(5);
        ChangeColors(7);
        Verify();
    }

    public void Pressed6()
    {
        lightArray[2] = !lightArray[2];
        lightArray[4] = !lightArray[4];
        lightArray[5] = !lightArray[5];
        lightArray[8] = !lightArray[8];
        ChangeColors(2);
        ChangeColors(4);
        ChangeColors(5);
        ChangeColors(8);
        Verify();
    }

    public void Pressed7()
    {
        lightArray[3] = !lightArray[3];
        lightArray[6] = !lightArray[6];
        lightArray[7] = !lightArray[7];
        ChangeColors(3);
        ChangeColors(6);
        ChangeColors(7);
        Verify();
    }

    public void Pressed8()
    {
        lightArray[4] = !lightArray[4];
        lightArray[6] = !lightArray[6];
        lightArray[7] = !lightArray[7];
        lightArray[8] = !lightArray[8];
        ChangeColors(4);
        ChangeColors(6);
        ChangeColors(7);
        ChangeColors(8);
        Verify();
    }

    public void Pressed9()
    {
        lightArray[5] = !lightArray[5];
        lightArray[7] = !lightArray[7];
        lightArray[8] = !lightArray[8];
        ChangeColors(5);
        ChangeColors(7);
        ChangeColors(8);
        Verify();
    }
}
