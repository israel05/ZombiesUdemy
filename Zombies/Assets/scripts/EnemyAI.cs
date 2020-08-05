using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    bool isProvoked = false;
    
    float distanceToTarget = Mathf.Infinity;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }
    

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            
        }            
    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget < navMeshAgent.stoppingDistance)
        {

            AttackTarget();
        }

    }
      

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false); //entra en la animacion attack
        GetComponent<Animator>().SetTrigger("move"); //entra en la animacion move
        navMeshAgent.SetDestination(target.position);
    }
    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true); //entra en la animacion attack
        //if (GetComponent<Animator>().GetBool("attack"))
        //{
        //    print("LANZO ANIMACION ATTACK");
       // }
        GetComponent<Animator>().SetBool("attack", true);
        Debug.Log(name + " esta atacando a " + target.name);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
