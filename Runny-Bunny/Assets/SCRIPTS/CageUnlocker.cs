using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageController : MonoBehaviour
{
    private bool eKeyDown = false;
    private bool uKeyDown = false;
    private float holdTimerE = 0f;
    private float holdTimerU = 0f;
    public float holdDuration = 3f;
    public GameObject bunny1;
    public GameObject bunny2;
    public Collider2D cageCollider1; 
    public Collider2D cageCollider2; 

    void Update()
    {
        // Player 1 Key Handling
        if (Input.GetKeyDown(KeyCode.Q))
        {
            eKeyDown = true;
            holdTimerE = 0f; 
        }
        
        if (Input.GetKeyUp(KeyCode.Q))
        {
            eKeyDown = false;
            holdTimerE = 0f; 
        }

        if (eKeyDown)
        {
            holdTimerE += Time.deltaTime;

            if (holdTimerE >= holdDuration)
            {
                DisableCageColliders(cageCollider1);
                ReleaseBunny(bunny1);
                Debug.Log("Bunny1 can move!!");
            }
        }

        // Player 2 Key Handling
        if (Input.GetKeyDown(KeyCode.U))
        {
            uKeyDown = true;
            holdTimerU = 0f; 
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            uKeyDown = false;
            holdTimerU = 0f; 
        }

        if (uKeyDown)
        {
            holdTimerU += Time.deltaTime;

            if (holdTimerU >= holdDuration)
            {
                DisableCageColliders(cageCollider2);
                ReleaseBunny(bunny2);
                Debug.Log("Bunny2 can move!!");
            }
        }
    }

    void DisableCageColliders(Collider2D cageCollider)
    {
        
        cageCollider.enabled = false;
    }

    void ReleaseBunny(GameObject bunny)
    {
        // player movemnt acript is enabled btw
        bunny.GetComponent<PlayerMovement>().enabled = true;
    }
}