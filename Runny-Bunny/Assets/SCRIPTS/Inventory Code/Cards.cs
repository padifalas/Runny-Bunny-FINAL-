using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    private Player1Inventory inventory;

    private P1Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Player1Inventory>();
    }

    public void OnHealthClick()
    {
        Destroy(gameObject);
    }

    public void OnStaminaClick()
    {
        Destroy(gameObject);
    }

    public void OnMentalClick()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
