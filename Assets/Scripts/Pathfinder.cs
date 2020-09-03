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
        ExploreNeighbours();
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

    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = start.GetGridPosition() + direction;
            //print("Exploring : " + explorationCoordinates);
            if (grid.ContainsKey(explorationCoordinates))
            {
                grid[explorationCoordinates].SetColor(Color.blue);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
