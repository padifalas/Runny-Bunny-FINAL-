using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightClick : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent Player2Click;

    [SerializeField] private Color rightClickColour = Color.grey;

    [SerializeField] private float rightClickColourDuration = 0.1f;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Player2Click?.Invoke();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
