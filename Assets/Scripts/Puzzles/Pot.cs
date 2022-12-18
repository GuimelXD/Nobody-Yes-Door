using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private KeycardPuzzle keycardPuzzle;
    private bool completed = false;
    private float maxTime = 2;
    private float timeRemaining;
    private bool timerIsRunning;

    void OnCollisionEnter(Collision collision)
    {
        if (!completed && collision.gameObject.name == keycardPuzzle.keycardRed.name && gameObject.name == keycardPuzzle.potRed.name)
        {
            Acertou();
        }
        else if (!completed && collision.gameObject.name == keycardPuzzle.keycardGreen.name && gameObject.name == keycardPuzzle.potGreen.name)
        {
            Acertou();
        }
        else if (!completed && collision.gameObject.name == keycardPuzzle.keycardBlue.name && gameObject.name == keycardPuzzle.potBlue.name)
        {
            Acertou();
        }
        else if (!completed)
        {
            Debug.Log("errou");
            gameObject.GetComponent<MeshRenderer>().material = keycardPuzzle.materialRed;
            timerIsRunning = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        keycardPuzzle = gameObject.transform.parent.parent.GetComponent<KeycardPuzzle>();
    }

    // Update is called once per frame
    void Update()
    {

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out !");
                timeRemaining = maxTime;
                timerIsRunning = false;
                gameObject.GetComponent<MeshRenderer>().material = keycardPuzzle.materialBranco;
            }
        }
    }

    void Acertou()
    {
        Debug.Log("acertou");
        gameObject.GetComponent<MeshRenderer>().material = keycardPuzzle.materialGreen;
        keycardPuzzle.AddPoints();
        completed = true;
    }
}
