using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomeOnLoad : MonoBehaviour
{
    private Vector3 Pos2;
    public GameObject objeto;

    // Start is called before the first frame update
    void Start()
    {
        Pos2.Set(0, 2, 0);
        Instantiate(objeto, Pos2, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
