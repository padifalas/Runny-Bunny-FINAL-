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

    public AudioSource AudioSourceUnlocking;
    public AudioSource AudioSourceUnlocked;

    private bool Cage1Open;
    private bool Cage2Open;

    private void Start()
    {
        Cage1Open = false;
        Cage2Open = false;

        Slider1.maxValue = holdDuration;
        Slider2.maxValue = holdDuration;        
    }

    void Update()
    {
        // Player 1 Key Handling
        if(Cage1Open == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                qKeyDown = true;
                holdTimerQ = 0f;

                AudioSourceUnlocking.Play();
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                qKeyDown = false;
                holdTimerQ = 0f;

                AudioSourceUnlocking.Stop();
            }

            if (qKeyDown)
            {
                Slider1.value = holdTimerQ;

                holdTimerQ += Time.deltaTime;

                if (holdTimerQ >= holdDuration)
                {
                    Cage1Open = true;

                    AudioSourceUnlocked.Play();

                    DisableCageColliders(cageCollider1);
                    ReleaseBunny(bunny1);
                    Debug.Log("Bunny1 can move!!");
                }
            }
        }        

        // Player 2 Key Handling
        if (Cage2Open == false)
        {
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                ctrlKeyDown = true;
                holdTimerCtrl = 0f;

                AudioSourceUnlocking.Play();
            }

            if (Input.GetKeyUp(KeyCode.RightControl))
            {
                ctrlKeyDown = false;
                holdTimerCtrl = 0f;

                AudioSourceUnlocking.Stop();
            }

            if (ctrlKeyDown)
            {
                Slider2.value = holdTimerCtrl;

                holdTimerCtrl += Time.deltaTime;

                if (holdTimerCtrl >= holdDuration)
                {
                    Cage2Open = true;

                    AudioSourceUnlocked.Play();

                    DisableCageColliders(cageCollider2);
                    ReleaseBunny(bunny2);
                    Debug.Log("Bunny2 can move!!");
                }
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