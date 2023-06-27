using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Wave[] waves;
    public float waveRate = 5f;
    public static int CountEnemyAlive = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        foreach (Wave wave in waves)
        {
            foreach (EnemyType enemyType in wave.enemyTypes)
            {
                for (int i = 0; i < enemyType.count; i++)
                {
                    GameObject.Instantiate(enemyType.enemyPrefab, enemyType.startPoint.position, Quaternion.identity);
                    CountEnemyAlive++;
                    yield return new WaitForSeconds(1f / enemyType.rate);
                }
                while (CountEnemyAlive > 0)
                {
                    yield return 0;
                }
                yield return new WaitForSeconds(waveRate);
            }
        }
    }

}

