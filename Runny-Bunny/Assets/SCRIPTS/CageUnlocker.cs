using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CageController : MonoBehaviour
{
    private bool eKeyDown = false;
    private bool ZeroKeyDown = false;
    private float holdTimerE = 0f;
    private float holdTimer0 = 0f;
    public float holdDuration = 3f;
    public GameObject bunny1;
    public GameObject bunny2;
    public Collider2D cageCollider1; 
    public Collider2D cageCollider2;

    public Slider Slider1;
    public Slider Slider2;

    private void Start()
    {
        Slider1.maxValue = holdDuration;
        Slider2.maxValue = holdDuration;        
    }

    void Update()
    {
        // Player 1 Key Handling
        if (Input.GetKeyDown(KeyCode.E))
        {
            eKeyDown = true;
            holdTimerE = 0f; 
        }
        
        if (Input.GetKeyUp(KeyCode.E))
        {
            eKeyDown = false;
            holdTimerE = 0f; 
        }

        if (eKeyDown)
        {
            Slider1.value = holdTimerE;

            holdTimerE += Time.deltaTime;

            if (holdTimerE >= holdDuration)
            {
                DisableCageColliders(cageCollider1);
                ReleaseBunny(bunny1);
                Debug.Log("Bunny1 can move!!");
            }
        }

        // Player 2 Key Handling
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            ZeroKeyDown = true;
            holdTimer0 = 0f; 
        }

        if (Input.GetKeyUp(KeyCode.Keypad0))
        {
            ZeroKeyDown = false;
            holdTimer0 = 0f; 
        }

        if (ZeroKeyDown)
        {
            Slider2.value = holdTimer0;

            holdTimer0 += Time.deltaTime;

            if (holdTimer0 >= holdDuration)
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