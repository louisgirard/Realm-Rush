using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns;
    [SerializeField] GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for(;;)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
