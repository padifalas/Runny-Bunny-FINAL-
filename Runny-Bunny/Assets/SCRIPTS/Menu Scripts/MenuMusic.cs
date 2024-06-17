using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioSource Music;

    public GameObject MusicHolder;

    private void Awake()
    {
        DontDestroyOnLoad(MusicHolder);
    }

    // Start is called before the first frame update
    void Start()
    {
        Music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
