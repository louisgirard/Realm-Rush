using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [Range(1f, 20f)] [SerializeField] float gridSize = 10f;

    TextMesh textMesh;

    void Update()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPosition.y = 0f;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = snapPosition;

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPosition.x.ToString() + "," + snapPosition.z.ToString();
    }
}
