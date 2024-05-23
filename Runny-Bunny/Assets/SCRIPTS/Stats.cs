using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
