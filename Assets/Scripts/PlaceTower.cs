using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] Transform parent;
    Vector3 offset = new Vector3(0, 10.5f, 0.5f);
    bool towerPlaced = false;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !towerPlaced)
        {
            GameObject tower = Instantiate(towerPrefab, transform.position + offset, Quaternion.identity);
            tower.transform.parent = parent;
            towerPlaced = true;
        }
    }
}
