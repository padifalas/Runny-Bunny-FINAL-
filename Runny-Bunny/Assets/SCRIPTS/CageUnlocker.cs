using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CageController : MonoBehaviour
{
    private bool qKeyDown = false;
    private bool ctrlKeyDown = false;
    private float holdTimerQ = 0f;
    private float holdTimerCtrl = 0f;
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            qKeyDown = true;
            holdTimerQ = 0f; 
        }
        
        if (Input.GetKeyUp(KeyCode.Q))
        {
            qKeyDown = false;
            holdTimerQ = 0f; 
        }

        if (qKeyDown)
        {
            Slider1.value = holdTimerQ;

            holdTimerQ += Time.deltaTime;

            if (holdTimerQ >= holdDuration)
            {
                DisableCageColliders(cageCollider1);
                ReleaseBunny(bunny1);
                Debug.Log("Bunny1 can move!!");
            }
        }

        // Player 2 Key Handling
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            ctrlKeyDown = true;
            holdTimerCtrl = 0f; 
        }

        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            ctrlKeyDown = false;
            holdTimerCtrl = 0f; 
        }

        if (ctrlKeyDown)
        {
            Slider2.value = holdTimerCtrl;

            holdTimerCtrl += Time.deltaTime;

            if (holdTimerCtrl >= holdDuration)
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