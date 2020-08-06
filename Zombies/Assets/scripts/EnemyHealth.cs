using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float  hitPoints = 10f;
    [SerializeField] Collider collisionMesh;
    AudioSource myAudioSource;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    public void takeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken"); //llama a todas las que tengan esa funcion
        hitPoints -= damage;
        AudioSource.PlayClipAtPoint(enemyHitSFX, Camera.main.transform.position);
        print("AGHH ME QUEDA " + hitPoints + " DE VIDA");
    }

        
    private void KillEnemy()
    {
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }

}
