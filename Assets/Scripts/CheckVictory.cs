using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckVictory : MonoBehaviour
{
    EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySpawner.AllEnemiesSpawned())
        {
            var enemies = FindObjectsOfType<Enemy>();
            if(enemies.Length == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
