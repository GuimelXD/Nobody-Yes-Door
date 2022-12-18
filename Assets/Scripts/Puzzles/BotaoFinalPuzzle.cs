using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BotaoFinalPuzzle : MonoBehaviour
{
    private GameObject[] anchors;
    private int anchorIndex;
    bool started = false;
    GameObject baseButton;
    RoomManager roomManager;
    public float maxButtonTime;
    private float buttonTime;
    int lastAnchor;

    // Start is called before the first frame update
    void Start()
    {
        anchors = GameObject.FindGameObjectsWithTag("buttonAnchor");
        Debug.Log(gameObject.name);
        baseButton = GameObject.Find("Base");
        roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();
        buttonTime = maxButtonTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            buttonTime -= Time.deltaTime;
        }
        if (buttonTime < 0)
        {
            buttonTime = maxButtonTime;
            anchorIndex = Random.Range(0, anchors.Length);
            while (anchorIndex == lastAnchor)
            {
                anchorIndex = Random.Range(0, anchors.Length);
            }
            lastAnchor = anchorIndex;
            baseButton.transform.position = anchors[anchorIndex].transform.position;
        }
    }

    public void ButtonPress()
    {
        if (!started)
        {
            started = true;
            anchorIndex = Random.Range(0, anchors.Length);
            baseButton.transform.position = anchors[anchorIndex].transform.position;
            lastAnchor = anchorIndex;
            GameObject pilar = GameObject.Find("Pilar");
            Destroy(pilar);
        }
        else
        {
            roomManager.EndGame();
            Debug.Log("cabou");
        }
    }
}
