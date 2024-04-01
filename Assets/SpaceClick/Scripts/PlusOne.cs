using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlusOne : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject GOPanel;
    
    private int counter;

    PlusOneInputActions actions;

    private void Awake()
    {
        actions = new PlusOneInputActions();
        actions.Enable();
    }

    private void Start()
    {
        counter = 0;
        actions.Standard.Space.performed += SpacePressed;
    }


    private void SpacePressed(InputAction.CallbackContext ctx)
    {
        counter++;
        
        if (counter >= 3)
        {
            GOPanel.SetActive(true);
        }

        text.text = counter.ToString();
    }
}
