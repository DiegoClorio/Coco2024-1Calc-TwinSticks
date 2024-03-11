using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastsLogic : MonoBehaviour
{
    private RaycastInputActions actions;

    private void Awake()
    {
        actions = new RaycastInputActions();
        actions.Enable();
    }

    private void Start()
    {
        actions.Standard.Click.performed += ClickOnObject;
    }

    private void ClickOnObject(InputAction.CallbackContext ctx)
    {
        Vector3 rayOrigin = Camera.main.ScreenToWorldPoint(actions.Standard.MousePosition.ReadValue<Vector2>());

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector3.forward);

        if (hit.transform != null)
        {
            if (hit.transform.tag == "Cat")
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
