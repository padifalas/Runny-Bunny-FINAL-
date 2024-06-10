using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJackShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;
    private GameObject player2;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);
        //Debug.Log(distance);

        if (distance < 10)
        {
            timer += Time.deltaTime;

            if (timer > 1.5)
            {
                timer = 0;
                shoot();
            }
        }

        float distance2 = Vector2.Distance(transform.position, player2.transform.position);
        //Debug.Log(distance2);

        if (distance2 < 10)
        {
            timer += Time.deltaTime;

            if (timer > 1.5)
            {
                timer = 0;
                shoot();
            }
        }



    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
