using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public GameObject P1Win;

    public GameObject P2Win;


    // Start is called before the first frame update
    void Start()
    {
        P1Win.SetActive(false);

        P2Win.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            P1Win.SetActive(true);
        }

        if (collision.gameObject.tag == "Player2")
        {
            P2Win.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
