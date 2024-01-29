using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float reloadTime;

    private PlayerInputActions playerInputActions;
    private Rigidbody2D rb;
    private float fireRate;
    private bool canShoot;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerInputActions.Enable();
        playerInputActions.Standard.Shooting.performed += Shoot;

        canShoot = true;
    }

    void Update()
    {
        ReloadWeapon();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(playerInputActions.Standard.Movement.ReadValue<Vector2>().x, playerInputActions.Standard.Movement.ReadValue<Vector2>().y, 0).normalized;
        rb.AddForce(direction * speed);
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (canShoot)
        {
            string buttonName = context.control.name;

            switch (buttonName)
            {
                case "upArrow":
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 90));
                    break;

                case "downArrow":
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, -90));
                    break;

                case "leftArrow":
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 180));
                    break;

                case "rightArrow":
                    Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    break;
            }
        }

        canShoot = false;
    }

    private void ReloadWeapon()
    {
        if (fireRate > 0 && !canShoot)
        {
            fireRate -= Time.deltaTime;
        }
        else
        {
            canShoot = true;
            fireRate = reloadTime;
        }
    }
}
