using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpawner : MonoBehaviour
{
    private Vector3 posV;
    private int swordType;
    public GameObject spawnLocation;
    public GameObject swordName1;
    public GameObject swordName2;
    public GameObject swordName3;
    public GameObject swordName4;
    public GameObject swordName5;
    public GameObject swordName6;

    // Start is called before the first frame update
    void Start()
    {
        posV = spawnLocation.transform.position;
        swordType = Random.Range(0, 6);
        switch (swordType)
        {
            case 0:
                SpawnSword(swordName1, posV);
                break;
            case 1:
                SpawnSword(swordName2, posV);
                break;
            case 2:
                SpawnSword(swordName3, posV);
                break;
            case 3:
                SpawnSword(swordName4, posV);
                break;
            case 4:
                SpawnSword(swordName5, posV);
                break;
            case 5:
                SpawnSword(swordName6, posV);
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSword(GameObject nome, Vector3 pos)
    {
        GameObject new_sword = Instantiate(nome, pos, Quaternion.identity);
    }
}
