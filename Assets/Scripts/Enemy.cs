using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 200;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
