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

    public GameObject CardPanel2;
    public Button StamButton2;
    public Button HealthButton2;
    public Button MentalButton2;

    public GameObject CardPanel3;
    public Button StamButton3;
    public Button HealthButton3;
    public Button MentalButton3;


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


    public void OnStaminaClick2()
    {
        CardPanel2.SetActive(false);

        StamButton2.interactable = false;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;

                Instantiate(StamCard, inventory.slots[i].transform, false);

                break;
            }
        }
    }
    public void OnHealthClick2()
    {
        CardPanel2.SetActive(false);

        HealthButton2.interactable = false;

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
    public void OnMentalClick2()
    {
        CardPanel2.SetActive(false);

        MentalButton2.interactable = false;

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

    public void OnStaminaClick3()
    {
        CardPanel3.SetActive(false);

        StamButton3.interactable = false;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;

                Instantiate(StamCard, inventory.slots[i].transform, false);

                break;
            }
        }
    }
    public void OnHealthClick3()
    {
        CardPanel3.SetActive(false);

        HealthButton3.interactable = false;

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
    public void OnMentalClick3()
    {
        CardPanel3.SetActive(false);

        MentalButton3.interactable = false;

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
