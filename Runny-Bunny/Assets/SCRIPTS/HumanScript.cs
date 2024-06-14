using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanScript : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;

    public GameObject P1Spawn;
    public GameObject P2Spawn;

    public GameObject Player1;
    public GameObject Player2;
   
    public float Speed;    

    private Rigidbody2D rb;

    private Transform CurrentPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        CurrentPoint = PointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = CurrentPoint.position - transform.position;

        if(CurrentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(Speed, 0);
        }

        else
        {
            rb.velocity = new Vector2(-Speed, 0);
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 2f)
        {
            CurrentPoint = (CurrentPoint == PointB.transform) ? PointA.transform : PointB.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player1.transform.position = P1Spawn.transform.position;

            Debug.Log("Player 1 caught");

            CurrentPoint.position = PointA.transform.position;
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            Player2.transform.position = P1Spawn.transform.position;

            Debug.Log("Player 2 caught");

            CurrentPoint.position = PointA.transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 2f);

        Gizmos.DrawWireSphere(PointB.transform.position, 2f);
    }
}
