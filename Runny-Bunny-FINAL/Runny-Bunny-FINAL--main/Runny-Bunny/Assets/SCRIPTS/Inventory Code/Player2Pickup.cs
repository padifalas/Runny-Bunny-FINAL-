using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Pickup : MonoBehaviour
{
    private Player2Inventory inventory;

    public GameObject StamCard;

    public GameObject HealthCard;

    public GameObject MentalCard;

    public GameObject CardPanel;

    public Button StamButton;

    public Button HealthButton;

    public Button MentalButton;

    public int i;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2Inventory>();
    }

    public void OnStaminaClick()
    {
        CardPanel.SetActive(false);

        StamButton.interactable = false;

        for(int i = 0; i < inventory.slots.Length; i++)
        {
           if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;

                Instantiate(StamCard, inventory.slots[i].transform, false);

                break;
            }
        }
    }

    public void OnHealthClick()
    {
        CardPanel.SetActive(false);

        HealthButton.interactable = false;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;

                Instantiate(HealthCard, inventory.slots[i].transform, false);

                break;
            }
        }
    }

    public void OnMentalClick()
    {
        CardPanel.SetActive(false);

        MentalButton.interactable = false;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;

                Instantiate(MentalCard, inventory.slots[i].transform, false);

                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
