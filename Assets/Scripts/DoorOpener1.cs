using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorOpener1 : MonoBehaviour
{
    [SerializeField] private Animator panelBottom1 = null;
    [SerializeField] private Animator panelL1 = null;
    [SerializeField] private Animator panelR1 = null;
    [SerializeField] private Animator panelTop1 = null;
    [SerializeField] private Animator panelBottom2 = null;
    [SerializeField] private Animator panelL2 = null;
    [SerializeField] private Animator panelR2 = null;
    [SerializeField] private Animator panelTop2 = null;
    [SerializeField] private Animator panelBottom3 = null;
    [SerializeField] private Animator panelL3 = null;
    [SerializeField] private Animator panelR3 = null;
    [SerializeField] private Animator panelTop3 = null;
    [SerializeField] private Animator panelBottom4 = null;
    [SerializeField] private Animator panelL4 = null;
    [SerializeField] private Animator panelR4 = null;
    [SerializeField] private Animator panelTop4 = null;
    private bool doorOpen1 = false;
    private bool doorOpen2 = false;
    private bool doorOpen3 = false;
    private bool doorOpen4 = false;
    private string panelBottom = "Panel_Bottom";
    private string panelL = "Panel_L";
    private string panelR = "Panel_R";
    private string panelTop = "Panel_Top";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openDoors()
    {
        if (!doorOpen1)
        {
            openDoor1();
        }
        if (!doorOpen2)
        {
            openDoor2();
        }
        if (!doorOpen3)
        {
            openDoor3();
        }
        if (!doorOpen4)
        {
            openDoor4();
        }
    }

    void openDoor1()
    {
        panelBottom1.Play(panelBottom, 0, 0.0f);
        panelL1.Play(panelL, 0, 0.0f);
        panelR1.Play(panelR, 0, 0.0f);
        panelTop1.Play(panelTop, 0, 0.0f);
        doorOpen1 = true;
    }

    void openDoor2()
    {
        panelBottom2.Play(panelBottom, 0, 0.0f);
        panelL2.Play(panelL, 0, 0.0f);
        panelR2.Play(panelR, 0, 0.0f);
        panelTop2.Play(panelTop, 0, 0.0f);
        doorOpen2 = true;
    }

    void openDoor3()
    {
        panelBottom3.Play(panelBottom, 0, 0.0f);
        panelL3.Play(panelL, 0, 0.0f);
        panelR3.Play(panelR, 0, 0.0f);
        panelTop3.Play(panelTop, 0, 0.0f);
        doorOpen3 = true;
    }

    void openDoor4()
    {
        panelBottom4.Play(panelBottom, 0, 0.0f);
        panelL4.Play(panelL, 0, 0.0f);
        panelR4.Play(panelR, 0, 0.0f);
        panelTop4.Play(panelTop, 0, 0.0f);
        doorOpen4 = true;
    }
}
