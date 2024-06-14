using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJackBulletScript : MonoBehaviour
{
    private GameObject player;
    private GameObject player2;
    private GameObject Stats;
    private Rigidbody2D rb1;
    private Rigidbody2D rb2;
    public float force;
    private float timer;

    public P1Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Stats").GetComponent<P1Stats>();        

        rb1 = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction1 = player.transform.position - transform.position;
        rb1.velocity = new Vector2(direction1.x, direction1.y).normalized * force;

        float rot1 = Mathf.Atan2(-direction1.y, -direction1.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot1 + 100);


        rb2 = GetComponent<Rigidbody2D>();
        player2 = GameObject.FindGameObjectWithTag("Player2");

        Vector3 direction2 = player2.transform.position - transform.position;
        rb2.velocity = new Vector2(direction2.x, direction2.y).normalized * force;

        float rot2 = Mathf.Atan2(-direction2.y, -direction2.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot2 + 100);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Player 1");

            Destroy(gameObject);

            stats.Blackjack1();
        }

        if (other.gameObject.CompareTag("Player2"))
        {          
            Debug.Log("Hit Player 2");

            Destroy(gameObject);

            stats.Blackjack2();
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Hit the Ground");

            Destroy(gameObject);
        }
    }
}
