using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 200;
    [SerializeField] int moneyGiven = 1;
    [SerializeField] ParticleSystem damageParticles;
    [SerializeField] ParticleSystem deathParticles;

    MoneyBoard moneyBoard;

    // Start is called before the first frame update
    void Start()
    {
        moneyBoard = FindObjectOfType<MoneyBoard>();

        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            yield return new WaitForSeconds(1f);
            transform.position = waypoint.transform.position;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        hitPoints--;
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
}
