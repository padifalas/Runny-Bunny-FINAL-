using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public GameObject P1Win;

    public GameObject P2Win;

    bool P1Won;

    bool P2Won;

    // Start is called before the first frame update
    void Start()
    {
        P1Win.SetActive(false);

        P2Win.SetActive(false);

        P1Won = false;

        P2Won = false;
    }

    public void Player1()
    {
        P1Won = true;

        P2Won = false;
        
        P1Win.SetActive (true);

        P2Win.SetActive (false);

        Debug.Log("player1 wins");
       
    }

    public void Player2()
    {
        P1Won = false;

        P2Won = true;

        P1Win.SetActive(false);

        P2Win.SetActive(true);

        Debug.Log("player2 wins");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (P1Won == false)
            {
                if (P2Won == false)
                {
                    Player1();

                    P1Won = true;
                }

                else
                {
                    Debug.Log("Player2 already won");
                }
            }            
        }

        if (collision.gameObject.tag == "Player2")
        {
            if (P1Won == false)
            {
                if (P2Won == false)
                {
                    Player2();

                    P2Won = true;
                }

                else
                {
                    Debug.Log("Player1 already won");
                }
            }                       
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
