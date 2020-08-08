using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickups : MonoBehaviour
{

    [SerializeField] int cantidadDeBalas = 10;
    [SerializeField] AmmoType ammoType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            FindObjectOfType<Ammo>().increaseAmmoAMount(ammoType, cantidadDeBalas);
            Destroy(gameObject);

        }
    }

}

