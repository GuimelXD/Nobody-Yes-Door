using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private Animator panelBottom = null;
    [SerializeField] private Animator panelL = null;
    [SerializeField] private Animator panelR = null;
    [SerializeField] private Animator panelTop = null;
    public bool doorOpen;
    private string panelBottomName = "Panel_Bottom";
    private string panelLName = "Panel_L";
    private string panelRName = "Panel_R";
    private string panelTopName = "Panel_Top";
    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openDoor()
    {
        if (!doorOpen)
        {
            panelBottom.Play(panelBottomName, 0, 0.0f);
            panelL.Play(panelLName, 0, 0.0f);
            panelR.Play(panelRName, 0, 0.0f);
            panelTop.Play(panelTopName, 0, 0.0f);
            doorOpen = true;
        }
    }
}
