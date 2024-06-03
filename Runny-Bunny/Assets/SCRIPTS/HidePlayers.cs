using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayers : MonoBehaviour
{
    GameObject Player1;

    GameObject Player2;

    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player");

        Player2 = GameObject.FindGameObjectWithTag("Player2");

        Player1.SetActive(false);

        Player2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
