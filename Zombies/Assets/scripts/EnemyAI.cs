﻿using System;
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
    void OnDrawGizmosSelected()
    {
        Gizmos.color =  Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
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
        if (distanceToTarget >=navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget < navMeshAgent.stoppingDistance)
        {

            AttackTarget();
        }

    }

    private void AttackTarget()
    {
        Debug.Log(name + " esta atacando a " + target.name ) ;
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }
}
