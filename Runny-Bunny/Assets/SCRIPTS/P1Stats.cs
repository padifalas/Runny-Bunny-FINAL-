using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class P1Stats : MonoBehaviour
{
    //public TextMeshProUGUI HealthTxt;
    public float Health = 5;

    //public TextMeshProUGUI StaminaTxt;
    public float Stamina = 1;

    //public TextMeshProUGUI MentalTxt;
    public float Mental = 1;

    //public TextMeshProUGUI HealthTxt2;
    public float Health2 = 5;

    //public TextMeshProUGUI StaminaTxt2;
    public float Stamina2 = 1;

    //public TextMeshProUGUI MentalTxt2;
    public float Mental2 = 1;   

    public GameObject Player1;
    public GameObject Player2;

    public GameObject P1Spawn;
    public GameObject P2Spawn;

    public Slider H1;
    public Slider H2;

    public Slider S1;
    public Slider S2;

    public Slider M1;
    public Slider M2;

    public GameObject CardPanel1;
    public GameObject CardPanel2;
    public GameObject CardPanel3;

    public float StaminaAdded;

    public AudioSource StatAudio;

    public AudioClip BoostSound, HurtSound, EAttackSound, GAttackSound, KillSound, EatSound, RestartSound;

    public void OnHealthClick()
    {       
        Health += 2;

        H1.value = Health;

        StatAudio.clip = BoostSound;
        StatAudio.Play();

        CardPanel1.SetActive(false);
        CardPanel2.SetActive(false);
        CardPanel3.SetActive(false);

        //HealthTxt.text = "Health: " + Health;
    }
    public void OnMentalClick()
    {
        Mental += 1;

        M1.value = Mental;

        CardPanel1.SetActive(false);
        CardPanel2.SetActive(false);
        CardPanel3.SetActive(false);

        //MentalTxt.text = "Mental: " + Health;
    }

    public void OnStaminaClick()
    {
        Stamina += 3;

        S1.value = Stamina;

        StatAudio.clip = BoostSound;
        StatAudio.Play();

        CardPanel1.SetActive(false);
        CardPanel2.SetActive(false);
        CardPanel3.SetActive(false);

        //StaminaTxt.text = "Stamina: " + Stamina;
    }


    public void OnHealth2Click()
    {
        Health2 += 2;

        H2.value = Health2;

        StatAudio.clip = BoostSound;
        StatAudio.Play();

        CardPanel1.SetActive(false);
        CardPanel2.SetActive(false);
        CardPanel3.SetActive(false);

        //HealthTxt2.text = "Health: " + Health2;
    }
    public void OnMental2Click()
    {
        Mental2 += 1;

        M2.value = Mental2;

        CardPanel1.SetActive(false);
        CardPanel2.SetActive(false);
        CardPanel3.SetActive(false);

        //MentalTxt2.text = "Mental: " + Health2;
    }

    public void OnStamina2Click()
    {            
        Stamina2 += 3;

        S2.value = Stamina2;

        Debug.Log(Stamina2);

        StatAudio.clip = BoostSound;
        StatAudio.Play();

        CardPanel1.SetActive(false);
        CardPanel2.SetActive(false);
        CardPanel3.SetActive(false);        

        //StaminaTxt2.text = "Stamina: " + Stamina2;
    }


    public void GnomeAttack1()
    {
        Health -= 1;

        H1.value = Health;

        StatAudio.clip = GAttackSound;
        StatAudio.Play();

        //HealthTxt.text = "Health: " + Health;
    }
    public void GnomeAttack2()
    {
        Health2 -= 1;

        H2.value = Health2;

        StatAudio.clip = GAttackSound;
        StatAudio.Play();

        //HealthTxt2.text = "Health: " + Health2;
    }


    public void Blackjack1()
    {
        Health -= 0.5f;

        H1.value = Health;

        StatAudio.clip = HurtSound;
        StatAudio.Play();

        //HealthTxt.text = "Health: " + Health;
    }
    public void Blackjack2()
    {
        Health2 -= 0.5f;

        H2.value = Health2;

        StatAudio.clip = HurtSound;
        StatAudio.Play();

        //HealthTxt2.text = "Health: " + Health2;
    }


    public void EagleAttack1()
    {
        Health -= 1;

        H1.value = Health;

        StatAudio.clip = EAttackSound;
        StatAudio.Play();

        //HealthTxt.text = "Health: " + Health;
    }
    public void EagleAttack2()
    {
        Health2 -= 1;

        H2.value = Health2;

        StatAudio.clip = EAttackSound;
        StatAudio.Play();

        //HealthTxt2.text = "Health: " + Health2;
    }


    public void EnemyKill1()
    {
        Mental += 1;

        M1.value = Mental;

        //MentalTxt.text = "Mental: " + Mental;

        StatAudio.clip = KillSound;
        StatAudio.Play();

        //MentalTxt2.text = "Mental: " + Mental2;
    }
    public void EnemyKill2()
    {
        Mental2 += 1;

        M2.value = Mental2;

        //MentalTxt2.text = "Mental: " + Mental2;        

        StatAudio.clip = KillSound;
        StatAudio.Play();

        //MentalTxt.text = "Mental: " + Mental;
    }


    public void Tomato1()
    {
        Stamina += 1;

        S1.value = Stamina;

        StatAudio.clip = EatSound;
        StatAudio.Play();

        //StaminaTxt.text = "Stamina: " + Stamina;
    }
    public void Tomato2()
    {
        Stamina2 += 1;

        S2.value = Stamina2;

        StatAudio.clip = EatSound;
        StatAudio.Play();

        //StaminaTxt2.text = "Stamina: " + Stamina2;
    }

    public void PoisonM1()
    {
        Health -= 2;

        H1.value = Health;

        StatAudio.clip = EatSound;
        StatAudio.Play();

        //StaminaTxt.text = "Stamina: " + Stamina;
    }
    public void PoisonM2()
    {
        Health2 -= 2;

        H2.value = Health2;

        StatAudio.clip = EatSound;
        StatAudio.Play();

        //StaminaTxt2.text = "Stamina: " + Stamina2;
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
        Stamina = 1f;
        Stamina2 = 1f;

        Mental = 1f;
        Mental2 = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Debug.Log("Player 1 Died");
            
            Health = 5;

            H1.value = Health;

            StatAudio.clip = RestartSound;
            StatAudio.Play();

            //HealthTxt.text = "Health: " + Health;

            Player1.transform.position = P1Spawn.transform.position;
        }

        if (Health2 <= 0)
        {
            Debug.Log("Player 2 Died");

            Health2 = 5;

            H2.value = Health2;

            StatAudio.clip = RestartSound;
            StatAudio.Play();

            //HealthTxt2.text = "Health: " + Health2;

            Player2.transform.position = P2Spawn.transform.position;
        }

        if (Stamina <= 0)
        {
            Debug.Log("Tired");

            Stamina = 0;

            S1.value = Stamina;
        }
    }
}
