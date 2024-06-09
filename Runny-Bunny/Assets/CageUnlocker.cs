using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageController : MonoBehaviour
{
    private bool eKeyDown = false;
    private float holdTimer = 0f;
    public float holdDuration = 5f;
    public GameObject bunny;
    public Collider2D cageCollider; 

    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.E))
        {
            eKeyDown = true;
            holdTimer = 0f; 
        }

        
        if (Input.GetKeyUp(KeyCode.E))
        {
            eKeyDown = false;
            holdTimer = 0f; 
        }

        
        if (eKeyDown)
        {
            holdTimer += Time.deltaTime;

            
            if (holdTimer >= holdDuration)
            {
                DisableCageColliders();
                ReleaseBunny();
                
                Debug.Log("Bunny1 can move!!");
            }
        }
    }

    void DisableCageColliders()
    {
        // Disable the cage collider
        cageCollider.enabled = false;
    }

    void ReleaseBunny()
    {
        //bunny movement script called hereee
        bunny.GetComponent<PlayerMovement>().enabled = true;
    }
}
