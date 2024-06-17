using UnityEngine;

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
