using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeJeffDetect : MonoBehaviour
{
    MazePuzzle mp;
    public GameObject mazePuzzle;
    private void OnTriggerEnter(Collider other)
    {
        mp.Verify(other.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        mp = mazePuzzle.GetComponent<MazePuzzle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
