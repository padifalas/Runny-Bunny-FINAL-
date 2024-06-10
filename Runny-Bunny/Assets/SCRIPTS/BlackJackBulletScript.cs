using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJackBulletScript : MonoBehaviour
{
    private GameObject player;
    private GameObject player2;
    private Rigidbody2D rb1;
    private Rigidbody2D rb2;
    public float force;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player2"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
