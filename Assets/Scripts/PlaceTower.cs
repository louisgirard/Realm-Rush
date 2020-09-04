using System;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] Transform parent;
    [SerializeField] int moneyPerTower = 5;

    Vector3 offset = new Vector3(0, 10.5f, 0.5f);
    GameObject towerPlaced;

    MoneyBoard moneyBoard;

    private void Start()
    {
        moneyBoard = FindObjectOfType<MoneyBoard>();
    }

    void OnMouseOver()
    {
        AddTower();
        RemoveTower();
    }

    private void AddTower()
    {
        if (Input.GetMouseButtonDown(0) && towerPlaced == null && moneyBoard.GetMoney() >= moneyPerTower)
        {
            towerPlaced = Instantiate(towerPrefab, transform.position + offset, Quaternion.identity);
            towerPlaced.transform.parent = parent;
            moneyBoard.AddMoney(-moneyPerTower);
        }
    }

    private void RemoveTower()
    {
        if(Input.GetMouseButtonDown(1) && towerPlaced != null)
        {
            Destroy(towerPlaced);
            moneyBoard.AddMoney(moneyPerTower);
        }
    }
}
