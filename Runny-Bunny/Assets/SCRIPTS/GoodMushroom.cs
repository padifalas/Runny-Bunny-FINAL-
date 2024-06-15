using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodMushroom : MonoBehaviour
{
    public P1Stats stats;

    bool StatChange1;

    bool StatChange2;

    // Start is called before the first frame update
    void Start()
    {
        StatChange1 = false;

        StatChange2 = false;

        stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<P1Stats>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StatChange1 = true;

            Debug.Log("Can Munch");
        }

        if (collision.gameObject.tag == "Player2")
        {
            StatChange2 = true;

            Debug.Log("Can Munch");
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            StatChange2 = false;
        }

        if (collision.gameObject.tag == "Player")
        {
            StatChange1 = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StatChange2 == true)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                Debug.Log("CRUNCH");

                //stats.PoisonM2();

                Destroy(gameObject);
            }
        }

        if (StatChange1 == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("CRUNCH");

                //stats.PoisonM1();

                Destroy(gameObject);
            }
        }
    }
}
