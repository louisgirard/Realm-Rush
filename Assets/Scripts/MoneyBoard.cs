using UnityEngine;
using UnityEngine.UI;

public class MoneyBoard : MonoBehaviour
{
    int money = 10;
    Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<Text>();
        moneyText.text = money.ToString();
    }

    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        moneyText.text = money.ToString();
    }

    public int GetMoney()
    {
        return money;
    }
}
