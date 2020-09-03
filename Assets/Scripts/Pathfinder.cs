using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint start, end;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        SetStartAndEndColor();
        BFS();
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

    private void SetStartAndEndColor()
    {
        start.SetColor(Color.green);
        end.SetColor(Color.red);
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
                PrintPath(current);
                return;
            }
            foreach (Vector2Int direction in directions)
            {
                Vector2Int explorationCoordinates = current.GetGridPosition() + direction;
                if (grid.ContainsKey(explorationCoordinates))
                {
                    Waypoint neighbour = grid[explorationCoordinates];
                    if (!neighbour.explored)
                    {
                        neighbour.parent = current;
                        queue.Enqueue(neighbour);
                    }
                }
            }
            current.explored = true;
        }
    }

    private void PrintPath(Waypoint current)
    {
        if(current.parent == null)
        {
            return;
        }
        else
        {
            PrintPath(current.parent);
            print(current.GetGridPosition());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
