using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OnSceneLoad : MonoBehaviour
{
    private Vector3 Pos;
    private int spawn;
    public GameObject nomeDaSala;
    private int aux = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int z = 0; z >= -30; z -= 10)
        {
            for (int x = 0; x >= -30; x -= 10)
            {
                Pos.Set(x, 0, z);
                spawn = Random.Range(0, 6);
                switch (aux)
                {
                    case 1:
                        SpawnRoom(nomeDaSala, Pos);
                        break;
                    case 16:
                        SpawnRoom(nomeDaSala, Pos);
                        //FAZER CÓDIGO DO FINAL
                        break;
                    default:
                        switch (spawn)
                        {
                            case 0:
                                SpawnRoom(nomeDaSala, Pos);
                                break;
                            case 1:
                                SpawnRoom(nomeDaSala, Pos);
                                break;
                            case 2:
                                SpawnRoom(nomeDaSala, Pos);
                                break;
                            case 3:
                                SpawnRoom(nomeDaSala, Pos);
                                break;
                            case 4:
                                SpawnRoom(nomeDaSala, Pos);
                                break;
                        }
                        break;
                }
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
