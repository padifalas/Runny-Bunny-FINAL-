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

    public GameObject Player1;
    public GameObject Player2;

    public GameObject P1Spawn;
    public GameObject P2Spawn;

    public void Died1()
    {
       
    }

    public void Died2()
    {
        
    }

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


    public void Blackjack1()
    {
        Health -= 1;

        HealthTxt.text = "Health: " + Health;
    }
    public void Blackjack2()
    {
        Health2 -= 1;

        HealthTxt2.text = "Health: " + Health2;
    }


    public void EagleAttack1()
    {
        Health -= 1;

        HealthTxt.text = "Health: " + Health;
    }
    public void EagleAttack2()
    {
        Health2 -= 1;

        HealthTxt2.text = "Health: " + Health2;
    }


    public void EnemyKill1()
    {
        Mental += 1;

        MentalTxt.text = "Mental: " + Mental;

        Mental2 -= 1;

        MentalTxt2.text = "Mental: " + Mental2;
    }
    public void EnemyKill2()
    {
        Mental2 += 1;

        MentalTxt2.text = "Mental: " + Mental2;

        Mental -= 1;

        MentalTxt.text = "Mental: " + Mental;
    }


    public void Tomato1()
    {
        Stamina += 1;

        StaminaTxt.text = "Stamina: " + Stamina;
    }
    public void Tomato2()
    {
        Stamina2 += 1;

        StaminaTxt2.text = "Stamina: " + Stamina2;
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
        if (Health <= 0)
        {
            Debug.Log("Player 1 Died");
            
            Health = 5;

            HealthTxt.text = "Health: " + Health;

            Player1.transform.position = P1Spawn.transform.position;
        }

        if (Health2 <= 0)
        {
            Debug.Log("Player 2 Died");

            Health2 = 5;

            HealthTxt2.text = "Health: " + Health2;

            Player2.transform.position = P2Spawn.transform.position;
        }
    }
}
