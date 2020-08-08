using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;


    /// <summary>
    /// Clase serializable, se puede usar más adelante
    /// </summary>
    [System.Serializable] 
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;

    }

    public int getammoammount(AmmoType ammoType)
    {
        
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    
    public void increaseAmmoAMount(AmmoType ammoType, int cantidadASubir)
    {
        GetAmmoSlot(ammoType).ammoAmount += cantidadASubir;
    }


    public void decreaseammoammount(AmmoType ammoType)
    {
        if (GetAmmoSlot(ammoType).ammoAmount > 0)
        {
            GetAmmoSlot(ammoType).ammoAmount--;
            print("me quedan :" + GetAmmoSlot(ammoType).ammoAmount + " balas");
        }
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
