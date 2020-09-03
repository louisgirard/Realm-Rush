using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint start, end;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        start.SetColor(Color.green);
        end.SetColor(Color.red);
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPosition());
            if (isOverlapping)
            {
                Debug.LogWarning("Overlapping block " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPosition(), waypoint);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
