using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMousePlayer : MonoBehaviour
{
    private MouseFollowActions actions;

    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        actions = new MouseFollowActions();
    }

    private void Start()
    {
        actions.Enable();
        actions.Standard.Fire.performed += FireBullet;

    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 dir = actions.Standard.Movement.ReadValue<Vector2>();
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void FireBullet(InputAction.CallbackContext ctx)
    {
        if (Camera.main.ScreenToWorldPoint(actions.Standard.MousePosition.ReadValue<Vector2>()).y > transform.position.y)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<FollowMouseBullet>().ChangeDirection(actions.Standard.MousePosition.ReadValue<Vector2>());
        }
    }
}
