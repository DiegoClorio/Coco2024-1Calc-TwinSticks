using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public GameObject catPrefab;
    public float timeBetweenCats;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    private float timer;

    private void Update()
    {
        if (timer <= 0)
        {
            float posX = Random.Range(minX, maxX);
            float posY = Random.Range(minY, maxY);

            Vector3 pos = new Vector3(posX, posY, 0);

            Instantiate(catPrefab, pos, Quaternion.identity);
            timer = timeBetweenCats;
        }
        else
        {
            timer = timer - Time.deltaTime;
        }
    }
}
