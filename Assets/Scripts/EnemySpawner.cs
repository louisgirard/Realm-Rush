using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float secondsBetweenSpawns;
    [SerializeField] GameObject enemy1Prefab;
    [SerializeField] GameObject enemy2Prefab;
    [SerializeField] GameObject boss1Prefab;
    [SerializeField] GameObject boss2Prefab;

    bool endWave = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    //Waves : 10 normal / 10 fast / 1 boss / 20 normals / 15 fast / big boss / 15 normals
    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(4f);

        GameObject enemy;
        // 10 normals
        for (int i = 0; i < 10; i++)
        {
            enemy = Instantiate(enemy1Prefab, transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
            secondsBetweenSpawns = 4;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        // 10 fast
        for (int i = 0; i < 10; i++)
        {
            enemy = Instantiate(enemy2Prefab, transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
            secondsBetweenSpawns = 1;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        // boss 1
        enemy = Instantiate(boss1Prefab, transform.position, Quaternion.identity);
        enemy.transform.parent = transform;
        // 20 normal
        for (int i = 0; i < 20; i++)
        {
            enemy = Instantiate(enemy1Prefab, transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
            secondsBetweenSpawns = 2;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        // 15 fast
        for (int i = 0; i < 15; i++)
        {
            enemy = Instantiate(enemy2Prefab, transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
            secondsBetweenSpawns = 1;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        // boss 2
        enemy = Instantiate(boss2Prefab, transform.position, Quaternion.identity);
        enemy.transform.parent = transform;
        // 10 normal
        for (int i = 0; i < 10; i++)
        {
            enemy = Instantiate(enemy1Prefab, transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
            secondsBetweenSpawns = 2;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        endWave = true;
    }

    public bool AllEnemiesSpawned()
    {
        return endWave;
    }
}
