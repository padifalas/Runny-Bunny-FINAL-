using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleAi : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    public float Speed;
    public float knockbackForce = 10f; // Knockback force to apply to the player

    private Rigidbody2D rb;
    private Transform CurrentPoint;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentPoint = PointB.transform;
    }

  
    void Update()
    {
        Vector2 point = CurrentPoint.position - transform.position;

        if (CurrentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(Speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-Speed, 0);
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 1.5f)
        {
            CurrentPoint = (CurrentPoint == PointB.transform) ? PointA.transform : PointB.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 1.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 1.5f);
    }
}