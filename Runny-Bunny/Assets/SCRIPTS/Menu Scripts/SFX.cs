using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource AudioSource;

    public AudioClip Click;

    // Start is called before the first frame update
    void Start()
    {
        
    } 

    public void OnPress()
    {
        AudioSource.clip = Click;

        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
