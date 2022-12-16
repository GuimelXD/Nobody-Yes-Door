using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour
{
    private Vector3 Pos;
    public GameObject[] sceneNameList;
    private int RandomOption;
    private int aux = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int z = 0; z >= -40; z -= 10)
        {
            for (int x = 0; x >= -40; x -= 10)
            {
                Pos.Set(x, 0, z);
                RandomOption = Random.Range(0, sceneNameList.Length);
                SpawnRoom(sceneNameList[RandomOption], Pos);
                
                aux++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRoom(GameObject nome, Vector3 Pos)
    {
        GameObject new_sala = Instantiate(nome, Pos, Quaternion.identity);
        new_sala.name = "sala." + aux;
    }
}
