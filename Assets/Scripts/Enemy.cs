using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movementPeriod = 1f;
    [SerializeField] int hitPoints = 200;
    [SerializeField] int moneyGiven = 1;
    [SerializeField] ParticleSystem damageParticles;
    [SerializeField] ParticleSystem deathParticles;

    MoneyBoard moneyBoard;
    LifeBoard lifeBoard;

    // Start is called before the first frame update
    void Start()
    {
        moneyBoard = FindObjectOfType<MoneyBoard>();
        lifeBoard = FindObjectOfType<LifeBoard>();

        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            yield return new WaitForSeconds(movementPeriod);
            transform.position = waypoint.transform.position;
        }
        GoalReached();
    }

    private void OnParticleCollision(GameObject other)
    {
        Bullet bullet = other.GetComponent<Bullet>();
        hitPoints -= bullet.GetDamage();
        if(hitPoints <= 0)
        {
            ProcessDeath();
        }
        else
        {
            damageParticles.Play();
        }
    }

    private void ProcessDeath()
    {
        moneyBoard.AddMoney(moneyGiven);
        ParticleSystem death = Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(death.gameObject, deathParticles.main.duration);

        Destroy(gameObject);
    }

    private void GoalReached()
    {
        lifeBoard.LoseLife(1);
        Destroy(gameObject, movementPeriod);
    }
}
