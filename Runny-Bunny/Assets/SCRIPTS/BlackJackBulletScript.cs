using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJackBulletScript : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;  
    
    private Rigidbody2D rb;   

    public float force;
    private float timer;

    public bool IsPlayer1;

    public AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        if (IsPlayer1 == true)
        {
            rb = GetComponent<Rigidbody2D>();
            player1 = GameObject.FindGameObjectWithTag("Player");

            Vector3 direction = player1.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 100);

        }

        else if(IsPlayer1 == false)
        {
            rb = GetComponent<Rigidbody2D>();
            player2 = GameObject.FindGameObjectWithTag("Player2");

            Vector3 direction2 = player2.transform.position - transform.position;
            rb.velocity = new Vector2(direction2.x, direction2.y).normalized * force;

            float rot2 = Mathf.Atan2(-direction2.y, -direction2.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot2 + 100);
        }       
        
        Audio.Play();
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
            Debug.Log("Hit Player 1");

            Destroy(gameObject);           
        }

        if (other.gameObject.CompareTag("Player2"))
        {          
            Debug.Log("Hit Player 2");

            Destroy(gameObject);          
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Hit the Ground");

            Destroy(gameObject);
        }
    }
}
