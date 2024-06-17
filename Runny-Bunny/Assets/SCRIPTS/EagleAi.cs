using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleAi : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    public float Speed;
    public float knockbackForce = 10f;

    public P1Stats stats;

    private Rigidbody2D rb;
    private Transform CurrentPoint;
    private bool facingRight = false; // Initially facing left since we need to switch directions

    public PlayerMovement playerMovement;
    public Player2Movement player2Movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentPoint = PointB.transform;
        if (!facingRight)
        {
            Flip();
        }

        stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<P1Stats>();
    }

    void Update()
    {
        Vector2 point = CurrentPoint.position - transform.position;

        if (CurrentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(Speed, 0);
            if (!facingRight)
            {
                Flip();
            }
        }
        else
        {
            rb.velocity = new Vector2(-Speed, 0);
            if (facingRight)
            {
                Flip();
            }
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 2f)
        {
            CurrentPoint = (CurrentPoint == PointB.transform) ? PointA.transform : PointB.transform;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.KCounter = playerMovement.KTime;

            if (collision.transform.position.x <= transform.position.x)
            {
                playerMovement.KnockRight = true;
            }

            if (collision.transform.position.x > transform.position.x)
            {
                playerMovement.KnockRight = false;
            }

            stats.EagleAttack1();
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            player2Movement.KCounter = player2Movement.KTime;

            if (collision.transform.position.x <= transform.position.x)
            {
                player2Movement.KnockRight = true;
            }

            if (collision.transform.position.x > transform.position.x)
            {
                player2Movement.KnockRight = false;
            }

            stats.EagleAttack2();
        }
    }    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 2f);
        Gizmos.DrawWireSphere(PointB.transform.position, 2f);
    }
}
