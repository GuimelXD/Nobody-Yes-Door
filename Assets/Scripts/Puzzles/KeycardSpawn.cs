using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardSpawn : MonoBehaviour
{
    public GameObject keycardRed;
    public GameObject keycardGreen;
    public GameObject keycardBlue;
    private GameObject[] spawnAnchors;
    private int RandomOption;

    // Start is called before the first frame update
    void Start()
    {
        spawnAnchors = GameObject.FindGameObjectsWithTag("cardSpawn");
        spawnCard(keycardRed);
        spawnCard(keycardGreen);
        spawnCard(keycardBlue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnCard(GameObject name)
    {
        RandomOption = Random.Range(0, spawnAnchors.Length);
        Instantiate(name, spawnAnchors[RandomOption].transform.position, Quaternion.identity);
    }
}
