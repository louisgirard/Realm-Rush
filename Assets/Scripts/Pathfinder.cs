using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint start, end;
    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

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

    private void BFS()
    {
        Queue<Waypoint> queue = new Queue<Waypoint>();
        start.explored = true;
        queue.Enqueue(start);
        while(queue.Count > 0)
        {
            Waypoint current = queue.Dequeue();
            if (current.Equals(end))
            {
                CreatePath(current);
                return;
            }
            foreach (Vector2Int direction in directions)
            {
                Vector2Int explorationCoordinates = current.GetGridPosition() + direction;
                if (grid.ContainsKey(explorationCoordinates))
                {
                    Waypoint neighbour = grid[explorationCoordinates];
                    if (!neighbour.explored && !queue.Contains(neighbour))
                    {
                        neighbour.parent = current;
                        queue.Enqueue(neighbour);
                    }
                }
            }
            current.explored = true;
        }
    }

    private void CreatePath(Waypoint current)
    {
        if(current.parent == null)
        {
            return;
        }
        else
        {
            CreatePath(current.parent);
            path.Add(current);
        }
    }

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        BFS();
        return path;
    }
}
