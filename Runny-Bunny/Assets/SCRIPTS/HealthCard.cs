using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCard : MonoBehaviour
{
    private Player1Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Player1Inventory>();
    }

    public void OnClick()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
