using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;

    public int GetAmmoAmmount()
    {
        return ammoAmount;
    }

    public void DecreaseAmmoAmmount()
    {
        if (ammoAmount > 0)
        {
            ammoAmount--;
            print("ME QUEDAN :" + ammoAmount + " BALAS");
        }
    }
}
