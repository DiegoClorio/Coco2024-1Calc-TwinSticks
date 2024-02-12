using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float pushForce;
    [SerializeField] private int maxHp;

    private Rigidbody2D rb;
    private int hp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = maxHp;
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = (Player.Instance.transform.position - transform.position).normalized;

        rb.AddForce(direction * speed);
    }

    public void Hit(int damage)
    {
        hp -= damage;
            
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Push();
        }
    }

    private void Push()
    {
        Vector3 direction = (transform.position - Player.Instance.transform.position).normalized;

        rb.AddForce(direction * pushForce, ForceMode2D.Impulse);
    }
}
