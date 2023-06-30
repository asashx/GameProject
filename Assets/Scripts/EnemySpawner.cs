using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        yield return new WaitForSeconds(2f);
        foreach(Wave wave in waves)
        {
            for(int i = 0; i < wave.enemyTypes.Length; i++)
            {
                EnemyType enemyType = wave.enemyTypes[i];
                for(int j = 0; j < enemyType.count; j++)
                {
                    if(enemyType.enemyPrefab != null)
                    {
                        GameObject.Instantiate(enemyType.enemyPrefab, enemyType.startPoint.position, Quaternion.identity);
                        CountEnemyAlive++;
                        if(j != enemyType.count - 1)
                        {
                            yield return new WaitForSeconds(enemyType.rate);
                        }
                    }
                }
                
            }
            while(CountEnemyAlive > 0)
                {
                    yield return 0;
                }
            yield return new WaitForSeconds(waveRate);
        }
        if (CountEnemyAlive == 0)
        {
            GameWin();
        }
        
    }

    void GameWin()
    {
        SceneManager.LoadScene(3);
    }

}

