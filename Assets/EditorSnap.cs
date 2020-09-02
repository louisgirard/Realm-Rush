using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    void Update()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x / 10f) * 10f;
        snapPosition.y = 0f;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / 10f) * 10f;

        transform.position = snapPosition;
    }
}
