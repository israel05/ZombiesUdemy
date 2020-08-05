using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
   
    [SerializeField] float damage = 40f;

    PLayerHealth target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PLayerHealth>();


    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.takeDamage(damage);
        print("BANG; BANG; MUERE TU MÁS PLAYER");
    }
}
