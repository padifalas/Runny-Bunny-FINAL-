using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class StopMenuMusic : MonoBehaviour
{
    GameObject MenuMusic;

    // Start is called before the first frame update
    void Start()
    {
        MenuMusic = GameObject.FindGameObjectWithTag("Music");

        Destroy(MenuMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
