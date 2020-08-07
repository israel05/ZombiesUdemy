﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float timeBetweenSHots = 0;
    [SerializeField] float damage = 24f;
   // [SerializeField] float delay = 2f;
    [SerializeField] ParticleSystem mozzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot; //cantida de balas ahora
   
    bool canShoot = true;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
              StartCoroutine(Shoot());           
        }     
    }

     IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetAmmoAmmount() > 0)
        {
            PlayMyzzleFlash();
            ProcessRayCast();
            ammoSlot.DecreaseAmmoAmmount();
        }       
        yield return new WaitForSeconds(timeBetweenSHots);
        canShoot = true;
    }

    private void PlayMyzzleFlash()
    {
        mozzleFlash.Play();
        print("Disparo");
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {

            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;            
            target.takeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact=Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);       
    }
}
