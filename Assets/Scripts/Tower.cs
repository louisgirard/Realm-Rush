using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem barrel;

    Enemy targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if(targetEnemy != null)
        {
            head.LookAt(targetEnemy.transform);
            ShootAtEnemy();
        }
        else
        {
            barrel.gameObject.SetActive(false);
        }
    }

    private void ShootAtEnemy()
    {
        float distance = Vector3.Distance(targetEnemy.transform.position, head.position);
        barrel.gameObject.SetActive(distance <= attackRange);
    }

    private void SetTargetEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if(enemies.Length == 0) { return; }

        float distance, bestDistance;
        targetEnemy = enemies[0];
        bestDistance = Vector3.Distance(targetEnemy.transform.position, head.position);

        foreach (Enemy enemy in enemies)
        {
            distance = Vector3.Distance(enemy.transform.position, head.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                targetEnemy = enemy;
            }
        }
    }
}
