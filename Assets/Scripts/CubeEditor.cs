using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    TextMesh textMesh;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();

        transform.position = new Vector3(waypoint.GetGridPosition().x * gridSize, 0f, waypoint.GetGridPosition().y * gridSize);
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = waypoint.GetGridPosition().x + "," + waypoint.GetGridPosition().y;
        gameObject.name = textMesh.text;
    }
}
