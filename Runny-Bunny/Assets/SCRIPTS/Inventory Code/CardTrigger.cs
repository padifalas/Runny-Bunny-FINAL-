using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTrigger : MonoBehaviour
{
    public GameObject CardPanel;

    // Start is called before the first frame update
    void Start()
    {
        CardPanel.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CardPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
