using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float  hitPoints = 10f;
    [SerializeField] Collider collisionMesh;

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
        hitPoints -= damage;
        print("AGHH ME QUEDA " + hitPoints + " DE VIDA");
    }

        
    private void KillEnemy()
    {
        Destroy(gameObject);
    }

}
