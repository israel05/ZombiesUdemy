using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickupElement : MonoBehaviour
{
    [SerializeField] float restoreAngle = 40f;
    [SerializeField] float addIntensity = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(addIntensity);
            Destroy(gameObject);
        }

    }
}
