using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem barrel;

    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        head.LookAt(targetEnemy);
        ShootAtEnemy();
    }

    private void ShootAtEnemy()
    {
        targetEnemy = FindObjectOfType<Enemy>().transform;
        float distance = Vector3.Distance(targetEnemy.position, head.position);
        barrel.gameObject.SetActive(distance <= attackRange);
    }
}
