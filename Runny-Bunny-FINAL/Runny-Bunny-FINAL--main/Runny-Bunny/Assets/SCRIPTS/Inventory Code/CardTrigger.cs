using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTrigger : MonoBehaviour
{
    public GameObject CardPanel;

    bool P1Enter;

    bool P2Enter;

    // Start is called before the first frame update
    void Start()
    {
        CardPanel.SetActive(false);

        P1Enter = false;

        P2Enter = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(P1Enter == false)
            {
                P1Enter = true;

                CardPanel.SetActive(true);
            }

            else
            {
                CardPanel.SetActive(false);
            }
        }

        if (collision.gameObject.tag == "Player2")
        {
            if (P2Enter == false)
            {
                P2Enter = true;

                CardPanel.SetActive(true);
            }

            else
            {
                CardPanel.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
