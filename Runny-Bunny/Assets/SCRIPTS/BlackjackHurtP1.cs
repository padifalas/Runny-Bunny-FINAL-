using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackjackHurtP1 : MonoBehaviour
{
    public P1Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<P1Stats>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blackjack"))
        {
            Debug.Log(stats.Health + "Player 1 Hit By Blackjack");

            stats.Blackjack1();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
