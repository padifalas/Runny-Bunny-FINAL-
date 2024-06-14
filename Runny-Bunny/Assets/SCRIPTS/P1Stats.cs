using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class P1Stats : MonoBehaviour
{
    public TextMeshProUGUI HealthTxt;

    public float Health = 5;

    public TextMeshProUGUI StaminaTxt;

    public float Stamina = 5;

    public TextMeshProUGUI MentalTxt;

    public float Mental = 5;

    public TextMeshProUGUI HealthTxt2;

    public float Health2 = 5;

    public TextMeshProUGUI StaminaTxt2;

    public float Stamina2 = 5;

    public TextMeshProUGUI MentalTxt2;

    public float Mental2 = 5;

    public bool Player1;

    public void OnHealthClick()
    {
        Health += 1;

        HealthTxt.text = "Health: " + Health;
    }
    public void OnMentalClick()
    {
        Mental += 3;

        MentalTxt.text = "Mental: " + Health;
    }

    public void OnStaminaClick()
    {
        Stamina += 2;

        StaminaTxt.text = "Stamina: " + Stamina;
    }
    public void OnHealth2Click()
    {
        Health2 += 1;

        HealthTxt2.text = "Health: " + Health2;
    }
    public void OnMental2Click()
    {
        Mental2 += 3;

        MentalTxt2.text = "Mental: " + Health2;
    }

    public void OnStamina2Click()
    {
        Stamina2 += 2;

        StaminaTxt2.text = "Stamina: " + Stamina2;
    }

    public void GnomeAttack1()
    {
        Health -= 1;

        HealthTxt.text = "Health: " + Health;
    }
    public void GnomeAttack2()
    {
        Health2 -= 1;

        HealthTxt2.text = "Health: " + Health2;
    }

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health -= 2;

            HealthTxt.text = "Health: " + Health;
        }

        if (collision.gameObject.tag == "Player2")
        {
            Health2 -= 2;

            HealthTxt2.text = "Health: " + Health2;
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
