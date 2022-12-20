using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDetect : MonoBehaviour
{
    public UnityEvent onCollision;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        onCollision.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
