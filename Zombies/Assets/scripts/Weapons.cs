using System;
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
    [SerializeField] AmmoType ammoType;

    bool canShoot = true;


    private void OnEnable()
    {
        canShoot = true;
    }

    

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
            if (ammoSlot.getammoammount(ammoType) > 0)
            {
                PlayMyzzleFlash();
                ProcessRayCast();
                ammoSlot.decreaseammoammount(ammoType);
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
            target.TakeDamage(damage);
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
