using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int power = 1;

    public int GetDamage()
    {
        return power;
    }
}
