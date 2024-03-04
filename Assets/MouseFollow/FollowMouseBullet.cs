using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToDestroy;

    private float timer;
    Vector3 dir;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToDestroy)
        {
            Destroy(gameObject);
        }

        transform.Translate(dir.normalized * speed * Time.deltaTime);
    }

    public void ChangeDirection(Vector2 mousePosition)
    {

        dir = Camera.main.ScreenToWorldPoint(mousePosition);
        dir.z = 0;
        dir = dir - transform.position;
    }
}
