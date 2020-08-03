using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] ParticleSystem projectileParticle;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }     
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            print("He alcanzado: " + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            target.takeDamage(25);
        }
       else
        {
            return;
        }

        
    }
}
