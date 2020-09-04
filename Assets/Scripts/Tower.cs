using System.Collections;
using System.Collections.Generic;
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
        targetEnemy = FindObjectOfType<Enemy>();
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
}
