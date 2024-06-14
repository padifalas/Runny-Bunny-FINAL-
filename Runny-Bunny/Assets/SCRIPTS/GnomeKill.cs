using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeKill : MonoBehaviour
{
    public GameObject Gnome;

    public P1Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<P1Stats>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(transform.parent.gameObject);

            stats.EnemyKill1();
        }

        if (collision.gameObject.tag == "Player2")
        {
            Destroy(transform.parent.gameObject);

            stats.EnemyKill2();
        }
    }

   
}
