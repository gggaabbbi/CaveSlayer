using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawTime;
    [SerializeField] Vector2 minSpawnPosition, maxSpawnPosition;

    void Start()
    {
        StartCoroutine(SpawnTime());
    }

    private IEnumerator SpawnTime()
    {
        while (true)
        {
            //SpawnTime
            float spawTime = Random.Range(minSpawnTime, maxSpawTime);
            yield return new WaitForSeconds(spawTime);

            //SpawnPosition
            float xPosition = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float yPosition = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
            Instantiate(prefab, new Vector2(xPosition, yPosition), Quaternion.identity);
        }
    }

}